start = 0;
copi = ones(1,480);
star = 0;
totalC = 1;
while star < 49
    while start < 11
        copi(1,totalC) = star;
        totalC = totalC + 1;
        start = start + 1;
    end
    start = 0;
    star = star + 1;
end