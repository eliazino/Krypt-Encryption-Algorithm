function [ arg ] = inflate( pixarr, mult)
%INFLATE Summary of this function goes here
%   Detailed explanation goes here
rownum = 89;
colnum = 89;
startrow = 1;
startcol = 1;
flow = zeros(88*mult);
while (startrow < rownum)
    while (startcol < colnum)
        zstr = pixarr(startrow, startcol);
        nxtrow = startrow *mult;
        nxtcol = startcol*mult;
        srow = (startrow * mult) + 1 - mult;
        scol = (startcol * mult) + 1 - mult;
        if (mult == 2)
            plug = [zstr zstr; zstr zstr];
        elseif (mult == 3)
            plug = [zstr zstr zstr; zstr zstr zstr; zstr zstr zstr];
        elseif mult == 4
             plug = [zstr zstr zstr zstr; zstr zstr zstr zstr; zstr zstr zstr zstr; zstr zstr zstr zstr];
        end
        flow(srow:nxtrow,scol:nxtcol) = plug;
        startcol = startcol + 1;
    end
    startcol = 1;
    startrow = startrow +1;
end
arg = flow;
end

