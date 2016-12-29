a = importdata('pixelate.txt', ' ');
b = importdata('pixlet.txt', ' ');
base = ones(40, 80);
minrow = 1;
mincol = 1;
maxrow = 40;
maxcol = 80;
startrow = 1; startcol = 1;
while (startrow < 41)
    while (startcol < 81)
        base(maxrow, maxcol) = b(minrow, mincol);
        startcol = startcol + 1;
        maxcol = maxcol - 1;
        mincol = mincol + 1;
    end
    startcol = 1;
    mincol = 1;
    maxcol = 80;
    startrow = startrow + 1;
    minrow = minrow + 1;
    maxrow = maxrow - 1;
end
bwrite = ones(88,88);
srow = 1;
scol =1;
while (srow < 5)
    while (scol < 17)
        bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 1;
    srow = srow + 1;
end
srow = 1; scol = 1;
while (srow < 17)
    while (scol < 5)
        bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 1;
    srow = srow + 1;
end
srow = 1; scol = 73;
while (srow < 5)
    while (scol < 88)
        bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 73;
    srow = srow + 1;
end
srow = 1; scol = 85;
while (srow < 17)
    while (scol < 89)
        bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 85;
    srow = srow + 1;
end
srow = 73; scol = 1;
while (srow < 89)
    while (scol < 5)
         bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 1;
    srow = srow + 1;
end
srow = 85; scol = 1;
while (srow < 89)
    while (scol < 17)
         bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 1;
    srow = srow + 1;
end
srow = 85; scol = 73;
while (srow < 89)
    while (scol < 89)
         bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 73;
    srow = srow + 1;
end
srow = 73; scol = 85;
while (srow < 89)
    while (scol < 89)
         bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 85;
    srow = srow + 1;
end
totalvar = [a; base];
bwrite(5:84, 5:84) = totalvar;
resp = input('Do you want to inflate the picture \n', 's');
if (strcmp(resp, 'yes') || strcmp(resp, 'Yes'))
    f = inflate(bwrite);
else 
    f = bwrite;
end
imwrite(f, 'crypt\fcrypt.png');