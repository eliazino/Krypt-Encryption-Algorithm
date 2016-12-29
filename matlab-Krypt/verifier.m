function [ uarg ] = verifier( imarr )
%UNTITLED2 Summary of this function goes here
%   Detailed explanation goes here
[x y z] = size(imarr);
prototype = zeros(16);
prototype(4:13,4:13) = 1;
stat = 1;
if (x > 88)
    imarr = deflate(imarr);
elseif (isequal(x,0) || isequal(y,0))
    stat = 0;
else
    imarr = imarr;
end
if isequal(stat,1)
f = ones(16);
%disp([x y]);
imarrsub = imarr(37:52,37:52);
f(1:3,1:16) = imarrsub(1:3,1:16);
f(4:13,1:3) = imarrsub(4:13,1:3);
f(4:13,14:16) = imarrsub(4:13,14:16);
f(14:16,1:16) = imarrsub(14:16,1:16);
if isequal(prototype,f)
    uarg = 1;
else
    uarg = 0;
end
else
    uarg = 0;
end
end

