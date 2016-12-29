function [ boolout ] = typeCounter( arr )
%UNTITLED5 Summary of this function goes here
%   Detailed explanation goes here
[x y z] = size(arr);
startX = 1;
startY = 1;
errs = 0;
while startX < x
    while startY < y
        j = arr(startX,startY);
        if ~isequal(j,0) || ~isequal(j,1) || ~isequal(j,255)
            boolout = 1;
            errs = errs + 1;
            break;
        else
            boolout = 0;
        end
        startY = startY + 1;
    end
startY = 1;
startX = startX + 1;
end
if(errs > 0)
    boolout = 1;
end
end

