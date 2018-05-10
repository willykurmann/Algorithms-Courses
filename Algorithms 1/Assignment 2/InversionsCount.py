'''
Programming Assignment #2 
==========================
Count the number of inversions in IntegerArray.txt
'''
import time

### Brute force version
def inversions_count_brute_force(a):
    n = len(a)
    inversions = 0
    for i in range(n):
        for j in range(i+1,n):
            if a[i] > a[j]:
                inversions += 1
    return inversions


### Divide and conquer version
def inversions_count(a):
    n = len(a)

    if n == 1:
        return a
    
    m = n/2 if n%2 == 0 else (n+1)/2

    left = a[:m]
    right = a[m:]

    a = inversions_count(left)
    b = inversions_count(right)
    c = sort_count(a,b)

    return c

def sort_count(a,b):
    global inversions
    lenA = len(a)
    lenB = len(b)
    c = []

    i,j = 0,0
    
    while i<lenA and j<lenB:
        if a[i] <= b[j]:
            c.append(a[i])
            i += 1
        else :
            c.append(b[j])
            j += 1
            inversions = inversions + (len(a) - i)
    
    if i == lenA:
        c.extend(b[j:])
    else:
        c.extend(a[i:])
    
    return c


### Program

# Read the file into a 1-n array
with open("IntegerArray.txt","r") as f:
    a = [int(x) for x in f.readlines()]

    # Run the brute-force version - ran approx. in 423 secs
    #start_time = time.time()
    #print("Brute Force")
    #print("Inversions={}".format(inversions_count_brute_force(a)))
    #print("--- %s seconds ---" % (time.time() - start_time))
    #print("")

    # Run the divide and conquer version - ran approx in 0.56 sec ! AMAAAAAAZZING !
    start_time = time.time()
    inversions = 0
    inversions_count(a)
    print("Divide and Conquer")
    print("Inversions={}".format(inversions))
    print("--- %s seconds ---" % (time.time() - start_time))
