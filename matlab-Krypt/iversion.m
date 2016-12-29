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
bwrite = ones(168,168);
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
srow = 1; scol = 153;
while (srow < 5)
    while (scol < 168)
        bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 153;
    srow = srow + 1;
end
srow = 1; scol = 165;
while (srow < 17)
    while (scol < 169)
        bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 165;
    srow = srow + 1;
end
srow = 153; scol = 1;
while (srow < 169)
    while (scol < 5)
         bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 1;
    srow = srow + 1;
end
srow = 165; scol = 1;
while (srow < 169)
    while (scol < 17)
         bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 1;
    srow = srow + 1;
end
srow = 165; scol = 153;
while (srow < 169)
    while (scol < 169)
         bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 153;
    srow = srow + 1;
end
srow = 153; scol = 165;
while (srow < 169)
    while (scol < 169)
         bwrite(srow,scol) = 0;
        scol = scol+1;
    end
    scol = 165;
    srow = srow + 1;
end
totalvar = [a; base];
tval = inflate(totalvar);
bwrite(5:164, 5:164) = tval;
imwrite(bwrite, 'crypt\infcrypt.png');