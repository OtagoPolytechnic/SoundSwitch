#include <vector>
#include <iostream>
#include <set>
#include <map>
#include <string>

#include "stdint.h"

#include "../AudioFile.h"
#include "../AudioStream.h"

#include "my_fingerprint.h"
#include "my_query.h"
#include "my_database.h"

#include <sys/time.h>

using std::vector;

uint64_t timeDiff(timeval &start, timeval &end) {
    uint64_t elapsed = end.tv_sec*1000000 + end.tv_usec - 
	(start.tv_sec*1000000 + start.tv_usec);
    return elapsed;
}

void printInt(size_t input) {
    for (size_t i = 0; i < 36; ++i) {
	std::cout << ((input >> (35-i)) & 1);
    }
    std::cout << std::endl;
}
int oldTest(int argc, char *argv[]) {
    if (argc < 2) {
	std::cout << "Wrong number of arguments, expected at least 1" << std::endl;
	return 1;
    }
    
    // if (a.getSampleRate() != 8192) {
    // 	std::cout << "Wrong sample rate for " << argv[1] << std::endl;
    // 	return 1;
    // }
    size_t collisions = 0;
    size_t maxInOneBucket = 0;
    size_t numberOfFingerPrints = 0;
    size_t numberOfBuckets = 0;
    size_t theMaxBucket = 0;
    size_t yetAnotherCounter = 0;
    for (size_t args = 1; args < argc; ++args) {

	AudioFile a(argv[args]);
	vector<int16_t> samples;
	a.getSamplesForChannel(0, samples);

	std::map<uint64_t,size_t> fingerprints;

	for (size_t i = 0; i+2048 < samples.size(); i+= 200) {
	    ++numberOfFingerPrints;
	    bool flag = false;
	    if (i+200+2048 >= samples.size()) flag = true;

	    my_fingerprint myf(samples.begin() + i, samples.begin() + i + 2048, flag);
	    size_t cnt = fingerprints.count(myf.getPrint());

	    if (myf.getPrint() == 60129542144LL) {
		++yetAnotherCounter;
		std::cout << args << " " <<  i << std::endl;
	    }

	    if (cnt > 0) {

		++fingerprints[myf.getPrint()];

		// statistics.
		++collisions;
		if (fingerprints[myf.getPrint()] > maxInOneBucket) {
		    maxInOneBucket = fingerprints[myf.getPrint()];
		    theMaxBucket = myf.getPrint();
		}
	    } else {
		fingerprints[myf.getPrint()] = 1;
		++numberOfBuckets;
	    }
	}
    }

    double avgBucketSize = static_cast<double>(numberOfFingerPrints) / static_cast<double>(numberOfBuckets);

    std::cout << "Number of buckets: " << numberOfBuckets << std::endl;
    std::cout << "Collisions: " << collisions << std::endl;
    std::cout << "maxInOneBucket: " << maxInOneBucket << std::endl;
    std::cout << "average bucket size: " << avgBucketSize << std::endl;
    std::cout << "# fingerprints: " << numberOfFingerPrints << std::endl;
    std::cout << "the max bucket: "; printInt(theMaxBucket);
    std::cout << "the max bucket: " << theMaxBucket << std::endl;

}

void printUsage() {
    std::cout << "Usage: ./test_my_fingerprint #db_files #query_files <db file 1> <...> <db file n> <query file 1> <...> <query file n>" << std::endl;
	
}

void printResult(vector<std::pair<size_t,double> > &results, size_t i, char * argv[]) {
    size_t mask = (1ULL<<36)-1;
    size_t seconds = (results[i].first & mask)/5512;
    std::cout << argv[3+(results[i].first>>40)] << " " << getTimestampFromSeconds(seconds)
	      << " " << results[i].second << std::endl;
}

int main(int argc, char * argv[]) {
//this program will be thrown away.
    my_database db;
    if (argc < 2) {
	//std::cout << "Wrong number of arguments, expected at least 1" << std::endl;
	printUsage();
	return 1;
    }

    int numDBFiles = atoi(argv[1]);
    int numQueryFiles = atoi(argv[2]);

    timeval dbBuildStart, dbBuildEnd, queryStart, queryEnd;
    gettimeofday(&dbBuildStart, NULL);

    //db.loadFromDisk("many_days.out");

    for (size_t arg = 3; arg < numDBFiles+3; ++arg) {
    	db.insert_file(argv[arg]);
    }
    gettimeofday(&dbBuildEnd, NULL);
    db.printStatistics();

    uint64_t elapsed = timeDiff(dbBuildStart, dbBuildEnd)/1000000;

    std::cout << "Time to build database: " << elapsed << " seconds" << std::endl;

    db.writeToDisk("many_days.out");
    
    for (size_t arg = 3+numDBFiles; arg < 3+numDBFiles+numQueryFiles; ++arg) {
    	std::string queryFile(argv[arg]);
	gettimeofday(&queryStart, NULL);
    	my_query myq(queryFile, db);
    	vector<std::pair<size_t,double> > results = myq.execute();
    	for (size_t i = 0; i < results.size(); ++i) {
    	    printResult(results, i, argv);
    	}
    	std::cout << "#results: " << results.size() << std::endl;
	gettimeofday(&queryEnd, NULL);
	elapsed = timeDiff(queryStart, queryEnd)/1000;
	std::cout << "Time to query database: " << elapsed << "milliseconds" << std::endl;
    }

    // while (true) {
    // 	char query[2048];
    // 	printf("Enter query: ");
    // 	scanf("%s", query);
    // 	my_query myq(query, db);
    // 	vector<size_t> results = myq.execute();
    // 	for (size_t i = 0; i < results.size(); ++i) {
    // 	    std::cout << results[i] << std::endl;
    // 	}
    // 	std::cout << "#results: " << results.size() << std::endl;
    // }

}
