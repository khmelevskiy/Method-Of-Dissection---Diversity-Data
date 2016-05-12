???
 **Method of dissection - diversity data**
___
**in this program only coding is made how to decode, I will describe below!**

At once I apologize for this translation, knowledge of English to me weak :(

---
In those information systems where the stored information (data) is placed in files, for ensuring confidentiality, besides enciphering the Method of dissection - diversity data can be used.
The essence of a method consists that the set of the protected data breaks into blocks which are carried on several other data sets. Each separate block doesn't bear a little significant information, and even access to full set of blocks doesn't allow to restore easily an initial data set without knowledge of a way of splitting.

---
**Example:**
---
Let the text (the $ symbol  corresponds to a space), which is required to be broken into 8 blocks be protected:МЕТОД$РАССЕЧЕНИЯ-РАЗНЕСЕНИЯ.
Will present the protected text in the form of the table consisting of four columns. For splitting it is required to choose two keys – for columns and for lines. The key consisting of the natural numbers equal to numbers of the columns (numbering begins with unit) randomized is compared to columns of the table. As in our table four columns with numbers from 1 to 4, as a key it is possible to take sequence {4-1-3-2}.

<center>![enter image description here](https://lh3.googleusercontent.com/6gyNGR1Mfhehki8W_yskdRGqN-TFEpt7Or9xMPy81Vs=s0 "table key-value.png")</center>

Now, if we denote r(i) value i position to the key string, across s(j) value j position to the key column, and by n - the number of columns, the number of the block K, which is placed in the next character of plaintext is determined by the expression:

***K = n (r(i) - 1) + s(j)***

**K - number of blocks**

**n - number of columns**

**r(i) - key of a line ({2,1})**

**s(j) - key of a column ({4,1,3,2})**

According to the set rule, the first symbol of the text "М" written in block number K = 4*(2-1) + 4 = 8.

Next symbol "Е" falls into block number K = 4*(2-1) + 1 = 5. 

The third symbol "Т" - in the block number K = 4*(2-1) + 3 = 7. And so on until the end of the text.

**Formed blocks will have the following content:**

![enter image description here](https://lh3.googleusercontent.com/ss6KjuZLXbh2REH_LIt28CQT7ysRMroqgJlVY4wNd-o=s0 "Blocks.png")

Thus, the clear text is replaced with eight blocks which length in the sum will give length of a source text.

#**Decode**
For decoding it is necessary to use "arrayKeys" from the file with a code. 

![enter image description here](https://lh3.googleusercontent.com/rat9INaLXPZiw3QR6_j7z0R3dad5W2UvGBCuE0golFk=s0 "IMG_20151001_001431.jpg")

Restoration of a source text is calculated on a formula:


***K = n (r(i) - 1) + s(j)***

Number of the block is calculated, from which the regular symbol is taken.

For example, for "M":

![enter image description here](https://lh3.googleusercontent.com/K8CAQbrOg54x22cEk0-clmdRUAs0UUjOiHV4996PkNI=s0 "IMG_20151001_001446.jpg")
that is M is in the block 8.

And for "E" complaining after it

![enter image description here](https://lh3.googleusercontent.com/zfe-Yryvme_wEEjkxmkoi1D9_AVqoyeKmeFSxkulXKg=s0 "IMG_20151001_001450.jpg")
that is E is in the block 5.

that is we pass according to all numbers of blocks and numbers of lines as it should be which was set by means of a random (column 4 and row 2; next column 1 and row 2; next column 3 and row 2; next column 2 and row 2; next column 4 and row 1 and so on, won't end a string yet).

In my code for obtaining value in the block, for example, it is possible to create a string variable and in it to write down values from the necessary block, and further to take the symbol, necessary on the account. 

**Code example in a rigid look:**

string temp = Convert.ToString(DictionaryBlockValue[necessaryBlock]);
DecodeString+= temp[necessaryLetter]

I won't describe full algorithm.


***Thanks for attention :) also I apologize for such translation and that didn't do decoding :(***
