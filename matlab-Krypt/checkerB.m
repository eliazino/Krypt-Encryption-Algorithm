function [ boolArg, pero, pert, total ] = checkerB( cMat )
%UNTITLED2 Summary of this function goes here
%   Detailed explanation goes here
perc = 0;
perc2 = 0;
counter = 1;
while counter < 81
    col = 1;
    while col < 3
        if cMat(counter, col) == 0
            perc = perc + 1;
        else
        end
        col = col+1;
    end
    counter = counter + 1;
end
counter = 1;
while counter < 81
    col = 79;
    while col < 81
        if cMat(counter, col) == 0
            perc2 = perc2 + 1;
        else
        end
        col = col+1;
    end
    counter = counter + 1;
end
if perc > perc2
    boolArg = 1;
else
    boolArg = 0;
end
pero = perc;
pert = perc2;
charO = cMat(7:7,41:48);
charT = cMat(8:8,41:48);
%disp(charO);
O = char(binDecode(charO));
P = char(binDecode(charT));
total = [O,P];
end

