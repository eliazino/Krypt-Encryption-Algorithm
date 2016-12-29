function [ recep ] = UNnoise( zind )
%UNTITLED4 Summary of this function goes here
%   Detailed explanation goes here
[x y z] = size(zind);
divisor = x/88;
startcol = 1;
startrow = 1;
rr = 1;
rc = 1;
recep = ones(88);
while startrow < x
    while startcol < y
        f = zind(startrow:startrow+divisor-1, startcol:startcol+divisor-1);
        zing = sum(sum(f));
        s = zing/(divisor*divisor);
        if s < 100
            recep(rr,rc) = 0;
        else
            recep(rr,rc) = 1;
        end
        rc = rc + 1;
        startcol = startcol+divisor;
    end
    rc = 1;
    startcol = 1;
    rr = rr + 1;
    startrow = startrow + divisor;
end

end

