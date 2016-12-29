motherMatrix = imread('crypt\fcrypt.png');
[a b] = size(motherMatrix);
if (a > 88 && b > 88)
    motherMatrix = deflate(motherMatrix);
else
end
considering = motherMatrix(5:44, 5:84);
countIndexOne = considering(20:20,39:42);
countIndexTwo = considering(21:21,39:42);
indexArray = considering(33:40, 1:80);
t_count = [countIndexOne , countIndexTwo];
int_count  = binDecode(t_count);
rowArray = ones(1,int_count);
colArray = ones(1,int_count);
returning = int_count*8*2 + 1;
counter = 0;
drone = ones(1,8);
mcount = 1;
continuity = 1;
straitCounter = 1;
rowcount = 1;
colcount = 1;
column = 1;
row = 1;
while (counter < returning)
    
    while (mcount < 9)
        if column > 80
            row = row + 1;
            column = 1;
        end
        drone(mcount) = indexArray(row, column);
        continuity = continuity + 1;
        mcount = mcount + 1;
        column = column + 1;
    end
    mcount = 1;
    counter = counter + 8;
    if (mod(straitCounter, 2) > 0)
        rowArray(rowcount) = binDecode(drone);
        rowcount = rowcount + 1;
    else
        colArray(colcount) = binDecode(drone);
        colcount = colcount + 1;
    end
    straitCounter = straitCounter + 1;
end
[c x] = size(rowArray);
rowArray = rowArray(1:1, 1:(x - 1));
counter = 1;
words = '';
while (counter < int_count + 1)
    nrow = rowArray(counter) +1;
    ncol = colArray(counter)+1;
    colstop = ncol + 7;
    c = considering(nrow:nrow, ncol:colstop);
    bequiv = binDecode(c);
    if bequiv == 24
        words(counter) = char(10);
    else
        words(counter) = char(bequiv);
    end
    counter = counter + 1;
end
disp(words);