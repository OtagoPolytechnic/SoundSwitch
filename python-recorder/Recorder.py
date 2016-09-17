import pyaudio
import wave
import audioop

chunk = 1024
FORMAT = pyaudio.paInt16
CHANNELS = 1
RATE = 44100
RECORD_SECONDS = 3
WAVE_OUTPUT_FILENAME = "unprocessed_.wav"

p = pyaudio.PyAudio()

s = p.open(format = FORMAT,
       channels = CHANNELS,
       rate = RATE,
       input = True,
       frames_per_buffer = chunk)

print("---recording---")

d = []

rms = 0

print((RATE / chunk) * RECORD_SECONDS)

while(rms < 2000):

    data = s.read(chunk)

    #Root mean squre = amplitude of sound
    rms = audioop.rms(data, 2)  #width=2 for format=paInt16

    print("---no sound detected--- Current sound val: ", rms)

    if (rms > 2000):
        for i in range(0, (RATE // chunk * RECORD_SECONDS)):
            currdata = s.read(chunk)
            currrms = audioop.rms(currdata, 2)
            print("---sound detected---  Current sound val: ", currrms)
            d.append(currdata)

        break

print("---done recording---")

s.close()
p.terminate()

wf = wave.open(WAVE_OUTPUT_FILENAME, 'wb')
wf.setnchannels(CHANNELS)
wf.setsampwidth(p.get_sample_size(FORMAT))
wf.setframerate(RATE)
wf.writeframes(b''.join(d))
wf.close()
