start = 0;
copi = ones(1,480);
copa = ones(1,480);
star = 0;
totalC = 1;
while start < 48
    while star < 73
        if start >= 0 && start <= 7
            if star == 32 || star == 40
            else
                copi(1,totalC) = star;
                copa(1,totalC) = start;
                totalC = totalC + 1;
            end
        elseif start >= 32 && start <= 47
            if star == 32 || star == 40
            else
                copi(1,totalC) = star;
                copa(1,totalC) = start;
                totalC = totalC + 1;
            end
        else
            copi(1,totalC) = star;
            copa(1,totalC) = start;
            totalC = totalC + 1;
        end
        star = star + 8;
    end
    star = 0;
    start = start + 1;
end