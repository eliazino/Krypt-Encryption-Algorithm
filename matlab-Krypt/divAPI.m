function [ outARG ] = divAPI( inputI )
%DIVAPI Summary of this function goes here
%   Detailed explanation goes here
numbersH = 1;
remainderH = inputI;
if (inputI >= 100)
    while remainderH >= 100
        remainderH = inputI - (100 * numbersH);
        numbersH = numbersH + 1;
    end
end
numbersT = 1;
inputT = remainderH;
remainderT = remainderH;
if (inputT >= 10)
    while remainderT >= 10
        remainderT = inputT - (10 * numbersT);
        numbersT = numbersT + 1;
    end
end
outARG = sum([numbersH-1 numbersT-1 remainderT]);

end

