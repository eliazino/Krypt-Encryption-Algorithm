function [ outArg ] = inverter( cMat )
%INVERTER Summary of this function goes here
%   Detailed explanation goes here
clone = ones(80);
row = 80;
cols = 80;
targRow = 1;
targCols = 1;
while row > 0
    while cols > 0
        clone(targRow, targCols) = cMat(row,cols);
        cols = cols - 1;
        targCols = targCols + 1;
    end
    cols = 80;
    targCols = 1;
    targRow = targRow + 1;
    row = row - 1;
end
outArg = clone;
end

