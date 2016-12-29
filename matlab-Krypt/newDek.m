function [keyS, status, every, dateV, TimeV] = newDek( motherMatrix, rgbstat)
%UNTITLED Summary of this function goes here
%   Detailed explanation goes here
s = typeCounter(motherMatrix);
if isequal(s,1)
    motherMatrix = UNnoise(motherMatrix);
else
end
statusM = '';
status = 0;
keyS = 'false';
[a b] = size(motherMatrix);
asciiEquiv = zeros(1,4);
if (a > 88 && b > 88)
    if mod(a,88) > 0
        str = 'Decryption was aborted due to Invalid picture properties';
       statusM = 'kill';
       errordlg(str, 'SomeError');
    else
         motherMatrix = deflate(motherMatrix);
    end
elseif ~isequal(a,b)
    str = 'Decryption was aborted due to Invalid picture properties';
    statusM = 'kill';
    errordlg(str, 'SomeError');
elseif mod(a,88) > 0
    str = 'Decryption was aborted due to Invalid picture properties';
       statusM = 'kill';
       errordlg(str, 'SomeError');
end
if strcmp(statusM, 'kill')    
else
   considering = motherMatrix(5:84, 5:84);
[~, ~, ~, tot] = checkerB(considering);
%disp([boolA pero pert, tot]);
if strcmp(tot,'AM') || strcmp( tot,'PM')
    %disp('Right pos');
else
    considering = inverter(considering);
   % disp('Image was inverted');
end
gmb = keyChecker(considering);
if (gmb > 0)
    %disp('Requesting a Key for the decryption');
     key =  inputdlg('Requesting a Key for the decryption', 'InputKeyDlg');
     keyS = 'true';
    %key = input('Key:', 's');
    if isempty(key)
        errordlg('The decryption was aborted by user!', 'Information', 'modal');
    end
    if (length(key{1}) > 4 || length(key{1}) < 4)
       str = 'Decryption was aborted due to CharCount Error. 4 characters are expected';
       statusM = 'kill';
       errordlg(str, 'SomeError');
    else
        keyz = key{1};
        asciiEquiv(1,1) = double(keyz(1:1));
        asciiEquiv(1,2) = double(keyz(2:2));
        asciiEquiv(1,3) = double(keyz(3:3));
        asciiEquiv(1,4) = double(keyz(4:4));
    end
else
    
end 
end
% pause;
if strcmp(statusM, 'kill')
    every =str;
    status = 0;
else
    countIndexOne = considering(40:40,39:42);
    countIndexTwo = considering(41:41,39:42);
    indexArray = considering(49:80, 1:80);
    t_count = [countIndexOne , countIndexTwo];
    int_count  = binDecode(t_count);
    if (int_count > 160 || int_count < 1)
        str = 'Decryption was aborted due to An unexpected error, the Krypt image might have been altered';
        every = str;
        msgbox(str, 'SomeError', 'error');
    else
        %disp(int_count);
        rowArray = ones(1,int_count+1);
        colArray = ones(1,int_count+1);
        returning = int_count*8*2+1;
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
            if (mod(straitCounter, 2) > 0) 
                a = binDecode(drone);
               % disp(a);
                if a > 99
                    remin = a - 100;
                    realval = 10 + remin;
                else
                    cind = a - 48;
                    realval = cind + 0;
                end
                %disp([rowcount realval]);
                rowArray(rowcount) = realval;
                rowcount = rowcount + 1;
            else
                 a = binDecode(drone);
                 %disp(a);
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
            if isequal(straitCounter,320)
                break;
            end
            straitCounter = straitCounter + 1;
             mcount = 1;
            counter = counter + 8;
        end
        [c x] = size(rowArray);
        rowArray = rowArray(1:1, 1:(x - 1));
        counter = 1;
        words = zeros(1,int_count);
        switcher = 0;
        while (counter < int_count + 1)
            nrow = rowArray(1,counter) +1;
            ncol = colArray(1,counter)+1;
            colstop = ncol + 7;
            %disp(int_count);
%             disp([rowArray; colArray]);
             c = considering(nrow:nrow, ncol:colstop);
            if switcher == 0
                adder = divAPI(asciiEquiv(1,1)) + divAPI(asciiEquiv(1,2));
                switcher = 1;
            else
                adder = divAPI(asciiEquiv(1,3)) + divAPI(asciiEquiv(1,4));
                switcher = 0;
            end
            bequiv = binDecode(c) - adder;
            if (bequiv == 24)
                words(counter) = 10;
            else
                words(counter) = bequiv;
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
%         welstr = ['.................................................', char(10), 'Created ', date, ' by ', time, int2str(int_count)];
        status = 1;
%         every = horzcat(welstr,words);
%         fileID = fopen('misc.txt','w');
%         fprintf(fileID, '%d \n', words);
        every = words;
        dateV = date;
        TimeV = time;
    end
end
end