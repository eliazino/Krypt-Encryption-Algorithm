function [ found ] = patternF( imarr )
%UNTITLED3 Summary of this function goes here
%   Detailed explanation goes here
s = typeCounter(imarr);
if isequal(s,1)
    imarr = contrast(imarr);
else
    
end
[x y z] = size(imarr);
sr = 1;
sc = 1;
found = 0;
while sr < x+1
    while sc < y+1
        nvar = imarr(sr,sc);
        if isequal(nvar,0)
            collectRow = sr;
            collectCol = sc;
            straitJacket = 0;
            counter = 0;
            while isequal(straitJacket,0)
                straitJacket = imarr(collectRow,collectCol);
                if isequal(collectCol,y)
                    break;
                else
                    collectCol = collectCol + 1;
                end
                counter = counter + 1;
            end
            counter = counter - 1;
            isValid = mod(counter,16);
            if isequal(isValid,0)
                multiplier = counter/16;
                rMark =sr + ((multiplier*4) -1);
                cMark =sc + counter -1;
                if rMark > x || cMark > y
                    sc = sc + 1;
                else
                    bench = imarr(rMark,cMark);
                if isequal(bench,0)
                    Ralt = sr + ((16*multiplier)-1);
                    if Ralt > x
                        sc = sc + 1;
                    else
                        bench = imarr(Ralt,sc);
                    if isequal(bench,0)
                        colStretch = ((multiplier*88)+ sc) -1;
                        rowStretch = ((multiplier*88)+ sr) -1;
                        if x < rowStretch || y < colStretch
                            sc = sc + 1;
                        else
                        aPoint = imarr(sr,colStretch);
                        bPoint = imarr(rowStretch,sc);
                        cPoint = imarr(rowStretch,colStretch);
                            if isequal(aPoint,bPoint,cPoint,0)                                
                                imvars = imarr(sr:rowStretch,sc:colStretch);
                                returnVar = verifier(imvars);
                                if isequal(returnVar,1)
                                found = found + 1;    
                                imwrite(imvars, ['found',num2str(found),'.j2c']);
                                %sr = rowStretch + 1;
                                sc = colStretch + 1;
                                else
                                    sc = sc + 1;
                                end
                            else
                                %sr = sr+1;
                                sc = sc+1;
                            end
                        end
                    else
                        sc = sc + 1;
                    end
                    end
                else
                    sc = sc + 1;
                end
                end
            else
                sc = sc + 1;
            end
        else
            sc = sc + 1;
        end
    end
    sc = 1;
    sr = sr + 1;
end

end

