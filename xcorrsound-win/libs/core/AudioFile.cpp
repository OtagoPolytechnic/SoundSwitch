#include "AudioFile.h"

#include <cstdio>
#include <cstring>
#include <vector>
#include <stdint.h>
#include <iostream>
#include <memory>

#include "my_utils.h"

using namespace std;

AudioFile::AudioFile(const char *path) : fd(fopen(path,"r")), _channels(0), _sampleRate(0),
					 _samplesPrChannel(0), _fileSize(0), _audioFormat(0),
					 _byteRate(0), _blockAlign(0), _bitsPrSample(0), _filename(path) {
    populateFieldVariables();
}


AudioFile::~AudioFile() {
    if (fd)
	fclose(fd);
    fd = NULL;
}

size_t AudioFile::getNumberOfChannels() {
    if (_channels) return _channels;
    populateFieldVariables();
    return this->_channels;
}

uint32_t AudioFile::getSampleRate() {
    return this->_sampleRate;
}

size_t AudioFile::getNumberOfSamplesPrChannel() {
    return this->_samplesPrChannel;
}

void AudioFile::getSamplesForChannelInRange(size_t begin, size_t end, vector<int16_t> &samples) {
    if (!(this->_startOfData))
	populateFieldVariables();

    samples.resize(end-begin);

    size_t toRead = (end-begin)*2*_channels;
    uint8_t *buf = new uint8_t[toRead];

    fseek(fd, _startOfData + begin * _channels * 2, SEEK_SET); // 2 bytes pr sample pr channel
    if (fread(buf, 1, toRead, fd) != toRead) {
	// error
	delete[] buf;
	return;
    }

    for (size_t i = 0; i < toRead; i+=4) {
	samples[i/4] = getIntFromChars(buf[i], buf[i+1]);
    }
    
    delete[] buf;
}

/**
 * @Deprecated. Use AudioStream instead.
 */
void AudioFile::getSamplesForChannel(size_t channel, std::vector<int16_t> &out) {
    // do something.
    fseek(fd, 0, SEEK_END);
    fseek(fd, this->_startOfData, SEEK_SET);
    uint8_t *buf = new uint8_t[2048];
    size_t currPos = this->_startOfData;
    size_t read = 0;
    while (!feof(fd)) {
        fseek(fd, read, SEEK_CUR);
        size_t read = fread(buf, 1, sizeof(buf), fd);	
        for (size_t i = 0; i < read; i+=4) {
            out.push_back(getIntFromChars(buf[i], buf[i+1]));
        }
        currPos += read;
    }
    delete[] buf;
}

void AudioFile::populateFieldVariables() {
    // find filesize.

    fseek(fd, 0, SEEK_END);
    this->_fileSize = ftell(fd);
    if (!(this->_fileSize)) return;

    // read first subchunk

    uint8_t buf[1024];
    fseek(fd, 0, SEEK_SET);
    size_t read = fread(buf, 1, 12, fd);    
    if (read < 12) return; // error.. should probably throw exception.
    size_t chunkSize = getIntFromChars(buf[4], buf[5], buf[6], buf[7]);
    if (chunkSize != _fileSize - 8) return; // error.. chunkSize is the byte size minus 8 of the file.
    
    // read start of next chunk to get size.
    read = fread(buf, 1, 8, fd);
    if (read < 8) return; // error..
    // size of rest of current subchunk. hopefully this is less than 100 bytes.
    size_t subChunk1Size = getIntFromChars(buf[4], buf[5], buf[6], buf[7]);

    read = fread(buf, 1, subChunk1Size, fd);
    if (read < subChunk1Size || read < 16) return; // error..

    this->_audioFormat = getIntFromChars(buf[0], buf[1]);
    this->_channels = getIntFromChars(buf[2], buf[3]);
    this->_sampleRate = getIntFromChars(buf[4], buf[5], buf[6], buf[7]);
    this->_byteRate = getIntFromChars(buf[8], buf[9], buf[10], buf[11]);
    this->_blockAlign = getIntFromChars(buf[12], buf[13]);
    this->_bitsPrSample = getIntFromChars(buf[14], buf[15]);

    read = fread(buf, 1, 1024, fd);
    
    // hopefully the following always works.. but it definitely might not.
    size_t startInBuf = 0;
    for (size_t i = 0; i < read-8; ++i) {
        if (buf[i] == 'd' && buf[i+1] == 'a' && buf[i+2] == 't' && buf[i+3] == 'a') {
            this->_startOfData = 12+8+subChunk1Size + i + 8;
            startInBuf = i+4;
            break;
        }
    }

    size_t subChunk2Size = getIntFromChars(buf[startInBuf],
                                           buf[startInBuf+1], 
                                           buf[startInBuf+2], 
                                           buf[startInBuf+3]);

    this->_samplesPrChannel = subChunk2Size * 8;
    this->_samplesPrChannel /= this->_bitsPrSample;
    this->_samplesPrChannel /= this->_channels;



}

AudioStream AudioFile::getStream(size_t channel) {
    if (!(this->_startOfData))        
        populateFieldVariables();
    return AudioStream(channel, this->_channels, this->_filename, this->_startOfData);
}
