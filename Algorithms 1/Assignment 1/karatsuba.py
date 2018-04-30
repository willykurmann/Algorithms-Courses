'''
Programming Assignment #1 
==========================
Implement karatsuba algorithm
Ref: algo1-intro3_typed.pdf
'''

def karatsuba(x, y):
    
    if len(str(x)) == 1 or len(str(y)) == 1:   
        return x * y

    n = max(len(str(x)),len(str(y)))
    m = n//2
   
    a = int(x / 10**m)
    b = int(x % 10**m)
    c = int(y / 10**m)
    d = int(y % 10**m)
    # Copied above section from https://pythonandr.com/2015/10/13/karatsuba-multiplication-algorithm-python-code/
    # Fact is that if you convert int to str and then split by half, it goes wrong somewhere but I still didnt figure out why.   

    ac = karatsuba(a,c)
    bd = karatsuba(b,d)
    abcd = karatsuba(a+b,c+d)
    #bc = karatsuba(b,c)
    #ad = karatsuba(a,d)
    
    return 10**n*ac + 10**m*(abcd - ac- bd) + bd 
    
value1 = 3141592653589793238462643383279502884197169399375105820974944592
value2 = 2718281828459045235360287471352662497757247093699959574966967627

print("result={}".format(karatsuba(value1,value2)))
print("expect={}".format(value1*value2))


