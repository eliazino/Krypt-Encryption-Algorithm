function [ outval ] = binDecode( inval)
%BINDECODE Summary of this function goes here
%   Detailed explanation goes here
binf = [128 64 32 16 8 4 2 1];
outval = 0;
[fvalid] = size(inval);
if (fvalid(2) ~= 8)
    error('Decoding process was aborted due to an invalid Arguement');
elseif (~(isnumeric(inval)))
    error('An error has occured due to invalid Arguement');
else
    start = 1;
    while start < 9
        d = inval(start);
        if (d > 1 && d ~= 255)
            disp(d);
            error('Invalid Arguement (at above) has caused the Process to terminate ');
        elseif (d == 1 || d ==255)
            outval = outval + binf(start);
        else
            
        end
        start = start + 1;
    end
end

end

