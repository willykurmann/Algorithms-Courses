'''
Programming Assignment #2 
==========================
Count the number of inversions in IntegerArray.txt
'''

import time

''' Brute-force version of the algorithm
'''
def count_inversion_bruteforce(a):
    n = len(a)
    inversions = 0
    for i in range(n):
        for j in range(i+1,n):
            if a[i] > a[j]:
                inversions += 1
    return inversions

# Read the file into a 1-n array
with open("SmallIntegerArray.txt","r") as f:
    content = f.readlines()
a = [x.strip() for x in content]

# Run the brute-force version
start_time = time.time()
print("inversions brute-force={}".format(count_inversion_bruteforce(a)))
print("--- %s seconds ---" % (time.time() - start_time))