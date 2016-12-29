function [ outMag ] = contrast( CMat  )
%UNTITLED2 Summary of this function goes here
%   Detailed explanation goes here
[x y z ] = size(CMat);
outMagn = ones(x,y);
if (z > 1)
    WorkOn = rgb2gray(CMat);
else
    WorkOn = CMat;
end
startX = 1;
startY = 1;
while (x > startX)
    while (y > startY)
        nV = WorkOn(startX, startY);
        if (nV > 110)
            outMagn(startX, startY) = 255;
        else
            outMagn(startX, startY) = 0;
        end
        startY = startY + 1;
    end
    startY = 1;
    startX = startX + 1;
end
outMag = outMagn;
end

