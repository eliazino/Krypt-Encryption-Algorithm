s = 1;
h =ones(1,160);
c = 1;
while s < 321
    if mod(s,2) > 0
        h(1,c) = s;
        c = c+1;
    end    
    s = s+1;
end