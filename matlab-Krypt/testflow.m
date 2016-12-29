pixarr = input('chicicu');
[f, j] = size(pixarr);
rownum = f + 1;
colnum = j + 1;
divisor = f/88;
startrow = divisor;
startcol = divisor;
flow = zeros(88);
while (startrow < rownum)
    while (startcol < colnum)
        zstr = pixarr(startrow, startcol);
        nxtrow = startrow / divisor;
        nxtcol = startcol / divisor;
        flow(nxtrow,nxtcol) = zstr;
        startcol = startcol + divisor;
    end
    startcol = divisor;
    startrow = startrow + divisor;
end
arg = flow;
imwrite(arg, 'jjc.png');