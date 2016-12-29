motherMatrix = imread('fcrypt.png');
[a b] = size(motherMatrix);
asciiEquiv = zeros(1,4);
if (a > 88 && b > 88)
    motherMatrix = deflate(motherMatrix);
else
end
considering = motherMatrix(5:84, 5:84);
[boolA, pero, pert, tot] = checkerB(considering);
%disp([boolA pero pert, tot]);
if strcmp(tot,'AM') || strcmp( tot,'PM')
    %disp('Right pos');
else
    considering = inverter(considering);
end
gmb = keyChecker(considering);
if (gmb > 0)
    disp('Requesting a Key for the decryption');
    answer = inputdlg('prompt');
    key = input('Key:', 's');
    if (length(key) > 4 || length(key) < 4)
        error('Decryption was aborted due to CharCount Error. 4 characters are expected');
    else
        asciiEquiv(1,1) = double(key(1:1));
        asciiEquiv(1,2) = double(key(2:2));
        asciiEquiv(1,3) = double(key(3:3));
        asciiEquiv(1,4) = double(key(4:4));
    end
else
    
end
% pause;
countIndexOne = considering(40:40,39:42);
countIndexTwo = considering(41:41,39:42);
indexArray = considering(49:80, 1:80);
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
        a = binDecode(drone);
        if a > 99
            remin = a - 100;
            realval = 10 + remin;
        else
            cind = a - 48;
            realval = cind + 0;
        end
        rowArray(rowcount) = realval;
        rowcount = rowcount + 1;
    else
         a = binDecode(drone);
        if a > 99
            remin = a - 100;
            realval = 10 + remin;
        else
            cind = a - 48;
            realval = cind + 0;
        end
        colArray(colcount) = realval;
        colcount = colcount + 1;
    end
    straitCounter = straitCounter + 1;
end
[c x] = size(rowArray);
rowArray = rowArray(1:1, 1:(x - 1));
counter = 1;
words = '';
switcher = 0;
while (counter < int_count + 1)
    nrow = rowArray(1,counter) +1;
    ncol = colArray(1,counter)+1;
    colstop = ncol + 7;
    c = considering(nrow:nrow, ncol:colstop);
    if switcher == 0
        adder = divAPI(asciiEquiv(1,1)) + divAPI(asciiEquiv(1,2));
        switcher = 1;
    else
        adder = divAPI(asciiEquiv(1,3)) + divAPI(asciiEquiv(1,4));
        switcher = 0;
    end
    bequiv = binDecode(c) - adder;
    if bequiv == 24
        words(counter) = char(10);
    else
        words(counter) = char(bequiv);
    end
    counter = counter + 1;
end
datcol = 33;
datrow = 1;
date = '';
time = '';
while datrow < 9
    if (datrow == 2 || datrow == 4)
        sep = '/';
    else
        sep = '';
    end
    nstr = considering(datrow:datrow, datcol:40);
    zf = binDecode(nstr);
    date = [date, char(zf),sep];
    datrow = datrow + 1;
end
datcol = 41;
datrow = 1;
while datrow < 9
    if (datrow == 2 || datrow == 4)
        sep = ':';
    elseif datrow == 6
        sep = ' ';
    else
        sep = '';
    end
    nstr = considering(datrow:datrow, datcol:48);
    zf = binDecode(nstr);
    time = [time, char(zf), sep];
    datrow = datrow + 1;
end
welstr = ['.................................................', char(10), 'Created ', date, ' by ', time];
disp(words);
disp(welstr);