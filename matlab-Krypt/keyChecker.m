function [ boolh ] = keyChecker( matr )
%KEYCHECKER Summary of this function goes here
%   Detailed explanation goes here
a = binDecode(matr(36:36, 37:44));
b = binDecode(matr(43:43, 37:44));
if (a == 153 && b == 231)
    boolh = 1;
else
    boolh = 0;
end

end

