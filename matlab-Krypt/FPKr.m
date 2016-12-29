function varargout = FPKr(varargin)
% FPKR MATLAB code for FPKr.fig
%      FPKR, by itself, creates a new FPKR or raises the existing
%      singleton*.
%
%      H = FPKR returns the handle to a new FPKR or the handle to
%      the existing singleton*.
%
%      FPKR('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in FPKR.M with the given input arguments.
%
%      FPKR('Property','Value',...) creates a new FPKR or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before FPKr_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to FPKr_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help FPKr

% Last Modified by GUIDE v2.5 01-Apr-2015 12:55:47

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @FPKr_OpeningFcn, ...
                   'gui_OutputFcn',  @FPKr_OutputFcn, ...
                   'gui_LayoutFcn',  [] , ...
                   'gui_Callback',   []);
if nargin && ischar(varargin{1})
    gui_State.gui_Callback = str2func(varargin{1});
end

if nargout
    [varargout{1:nargout}] = gui_mainfcn(gui_State, varargin{:});
else
    gui_mainfcn(gui_State, varargin{:});
end
% End initialization code - DO NOT EDIT


% --- Executes just before FPKr is made visible.
function FPKr_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to FPKr (see VARARGIN)

% Choose default command line output for FPKr
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);
javaFrame = get(hObject,'JavaFrame');
javaFrame.setFigureIcon(javax.swing.ImageIcon('text.png'));
guidata(hObject, handles);
axes(handles.axes1);
imshow('NOIM.j2c');
set(handles.text4, 'visible', 'off');
set(handles.text5, 'visible', 'off');
global pr;
global fcr;
global rgbpro;
global mult;
global K;
fcr = imread('NOIM.j2c');
pr = 'Error';
bg_image = imread('backw.jpg');
set(handles.pushbutton4, 'CData', bg_image);
bg_image = imread('forw.jpg');
set(handles.pushbutton5, 'CData', bg_image);
set(handles.pushbutton4, 'visible', 'off');
set(handles.pushbutton5, 'visible', 'off');


% UIWAIT makes FPKr wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = FPKr_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --------------------------------------------------------------------
function Untitled_1_Callback(hObject, eventdata, handles)
% hObject    handle to Untitled_1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)


% --------------------------------------------------------------------
function Untitled_2_Callback(hObject, eventdata, handles)
% hObject    handle to Untitled_2 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global pr;
global fcr;
global rgbpro;
global mult;
global K;
set(handles.text6, 'string', 'Busy');
[fn, pn] = uigetfile('*.jpg; *.png', 'Please select a krypt image');
imna = [pn, fn];
if isequal(imna,0) || isempty(imna) || ~ischar(imna)
    set(handles.text1,'string', 'Operation was cancelled by user! This usually is the consequence of pressing the cancel key on the dialogue, you can try that again');
else
    axes(handles.axes1);
    imshow(imna);
    set(handles.text1,'string', ['Image ',imna,' has been loaded. Now reading the image']);
    fcr = imread(imna);
    [x y z] = size(fcr);
    if z > 1
        msgbox('it was noticed that the image was not in good condition, Krypt engine will however try to work on the image','Information', 'help', 'modal');
        fcr = rgb2gray(fcr);
        rgbpro = 1;
    else
        rgbpro = 0;
    end
    if x < 88 || y < 88
        msgbox('The image is invalid outright and could not be read. Please request for another krypt image', 'Invalid Image','error', 'modal');
        set(handles.text1,'string', 'The image is invalid outright and could not be read. Please request for another krypt image');
    elseif (~isequal(x,y) || mod(x,88) > 0 || mod(y,88) > 0)
        mult = patternF(fcr);
        K = mult;
        if isequal(mult,0);
            errordlg('No Valid Krypt Image was found in the loaded image file, please try again with another image file ', 'Error');
            set(handles.text1,'string', 'Image was invalid');
        else
            if mult > 1
                msgbox(['You have loaded a multiple krypt image',char(10) ,num2str(mult), ' valid Krypt images were found',char(10),'Please navigate through the images and press decrypt at your choice image'], 'Information','help','modal')
                axes(handles.axes1);
                imshow(['found',num2str(1),'.j2c']);
                set(handles.pushbutton5, 'visible', 'on')
                set(handles.text5, 'visible', 'on');
                fcr  = imread(['found',num2str(1),'.j2c']);
            else
                msgbox(['You have loaded a non-concise krypt image', char(10),num2str(mult), ' valid Krypt image was found'], 'Information','help','modal')
                axes(handles.axes1);
                imshow(['found',num2str(1),'.j2c']);
                fcr  = imread(['found',num2str(1),'.j2c']);
            end
        end
        set(handles.text6, 'string', 'Idle');
    else
         [keyS, a, feedBack, dat, time] = newDek(fcr, rgbpro);
        if strcmp(keyS,'true')
            set(handles.edit1,'string', 'true');
        else
            set(handles.edit1,'string', 'false');
        end
        if (a == 1)
           set(handles.text3, 'visible', 'on');
           [~, b] = size(feedBack);
           disp(feedBack);
           sizzle = zeros(1,b);
           inc = 1;
           while inc < b+1
               x = feedBack(1,inc);
               if (x < 1)
                   sizzle(1, inc) = 10;
               else
                   sizzle(1, inc) = feedBack(1, inc);
               end
               inc = inc + 1;
           end
           f = sizzle
           disp(sizzle);
           welstr = ['.................................................', char(10), 'Created ', dat, ' by ', time];
           every = ['Image was decrypted as:', char(10), char(sizzle), char(10), welstr];
            set(handles.text3, 'string', every);
            pr = every;
        else
            later = get(handles.text1, 'string');
            set(handles.text1, 'string', [later, char(10), feedBack]);
            pr = 'Error';
        end    
    end
    set(handles.text6, 'string', 'Idle');
end






% --------------------------------------------------------------------
function Untitled_5_Callback(hObject, eventdata, handles)
% hObject    handle to Untitled_5 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)


% --- Executes on button press in pushbutton1.
function pushbutton1_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global pr;
global fcr;
global rgbpro;
global mult;
global K;
set(handles.text6, 'string', 'Busy');
[fn, pn] = uigetfile('*.jpg; *.png; *.*', 'Please select a krypt image');
imna = [pn, fn];
if isequal(imna,0) || isempty(imna) || ~ischar(imna)
    set(handles.text1,'string', 'Operation was cancelled by user! This usually is the consequence of pressing the cancel key on the dialogue, you can try that again');
else
axes(handles.axes1);
imshow(imna);
set(handles.text1,'string', ['Image ',imna,' has been loaded. Now reading the image']);
fcr = imread(imna);
[x y z] = size(fcr);
if z > 1
    msgbox('it was noticed that the image was not in good condition, Krypt engine will however try to work on the image','Information', 'help', 'modal');
    fcr = rgb2gray(fcr);
    rgbpro = 1;
else
    rgbpro = 0;
end
if x < 88 || y < 88
        msgbox('The image is invalid outright and could not be read. Please request for another krypt image', 'Invalid Image','error', 'modal');
        set(handles.text1,'string', 'The image is invalid outright and could not be read. Please request for another krypt image');
elseif ~isequal(x,y) || mod(x,88) > 0 || mod(y,88) > 0
    mult = patternF(fcr);
    K = mult;
    if isequal(mult,0);
        errordlg('No Valid Krypt Image was found in the loaded image file, please try again with another image file ', 'Error');
        set(handles.text1,'string', 'Image was invalid');
    else
        if mult > 1
            msgbox(['You have loaded a multiple krypt image',char(10) ,num2str(mult), ' valid Krypt images were found',char(10),'Please navigate through the images and press decrypt at your choice image'], 'Information','help','modal')
            axes(handles.axes1);
            imshow(['found',num2str(1),'.j2c']);
            set(handles.pushbutton5, 'visible', 'on')
            set(handles.text5, 'visible', 'on');
            fcr  = imread(['found',num2str(1),'.j2c']);
        else
            msgbox(['You have loaded a non-concise krypt image', char(10),num2str(mult), ' valid Krypt image was found'], 'Information','help','modal')
            axes(handles.axes1);
            imshow(['found',num2str(1),'.j2c']);
            fcr  = imread(['found',num2str(1),'.j2c']);
        end
    end
    set(handles.text6, 'string', 'Idle');
else
     [keyS, a, feedBack, dat, time] = newDek(fcr, rgbpro);
    if strcmp(keyS,'true')
        set(handles.edit1,'string', 'true');
    else
        set(handles.edit1,'string', 'false');
    end
    if (a == 1)
       set(handles.text3, 'visible', 'on');
       [~, b] = size(feedBack);
       sizzle = zeros(1,b);
       inc = 1;
       while inc < b+1
           x = feedBack(1,inc);
           if (x < 1)
               disp('true');
               sizzle(1, inc) = 10;
           else
               sizzle(1, inc) = feedBack(1, inc);
           end
           inc = inc + 1;
       end
       %disp(sizzle);
       welstr = ['.................................................', char(10), 'Created ', dat, ' by ', time];
       every = ['Image was decrypted as:', char(10), char(sizzle), char(10), welstr];
        set(handles.text3, 'string', every);
        pr = every;
    else
        later = get(handles.text1, 'string');
        set(handles.text1, 'string', [later, char(10), feedBack]);
        pr = 'Error';
    end    
end
set(handles.text6, 'string', 'Idle');
end




% --- Executes on button press in pushbutton2.
function pushbutton2_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton2 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
fileDir = 'C:\Program Files (x86)\Team Engine\Krypt Engine\Krypt.exe';
if exist(fileDir,'file') > 0
    winopen(fileDir);
else
    fileDir = 'C:\Program Files\Team Engine\Krypt Engine\Krypt.exe';
    if exist(fileDir, 'file') > 0
        winopen(fileDir);
    else
        strV = 'Something went wrong and the main Engine could not be started \n kindly start the application manually';
        errordlg(strV, 'Target Error','modal');
    end
end



function edit1_Callback(hObject, eventdata, handles)
% hObject    handle to edit1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of edit1 as text
%        str2double(get(hObject,'String')) returns contents of edit1 as a double


% --- Executes during object creation, after setting all properties.
function edit1_CreateFcn(hObject, eventdata, handles)
% hObject    handle to edit1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end


% --- Executes on button press in pushbutton3.
function pushbutton3_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton3 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global fcr;
global pr;
global rgbpro;
[x y z] = size(fcr);
if (z > 1)
    fcr = rgb2gray(fcr);
    rgbpro = 1;
else
    rgbpro = 0;
end
[keyS, a, feedBack, dat, time] = newDek(fcr, rgbpro);
if strcmp(keyS,'true')
    set(handles.edit1,'string', 'true');
else
    set(handles.edit1,'string', 'false');
end
if (a == 1)
   set(handles.text3, 'visible', 'on');
   [~, b] = size(feedBack);
   sizzle = zeros(1,b);
   inc = 1;
   while inc < b+1
       x = feedBack(1,inc);
       if (x < 1)
           sizzle(1, inc) = 10;
       else
           sizzle(1, inc) = feedBack(1, inc);
       end
       inc = inc + 1;
   end
%    disp(sizzle);
   welstr = ['.................................................', char(10), 'Created ', dat, ' by ', time];
   every = ['Image was decrypted as:', char(10), char(sizzle), char(10), welstr];
    set(handles.text3, 'string', every);
    pr = every;
else
    later = get(handles.text1, 'string');
    set(handles.text1, 'string', [later, char(10), feedBack]);
    pr = 'Error';
end


% --- Executes during object creation, after setting all properties.
function text3_CreateFcn(hObject, eventdata, handles)
% hObject    handle to text3 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called


% --------------------------------------------------------------------
function Untitled_6_Callback(hObject, eventdata, handles)
% hObject    handle to Untitled_6 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global pr;
if strcmp(pr,'Error')
    str = 'Nothing to write, Please load a Krypt image and try again';
        msgbox(str, 'SomeError', 'error');
else
%     special = '[]{}()=''.().....,;:%%{%}!@';
%     tStr = '¬`!"£$%^&*()_+=-{}[]:@~?><;''#,./\|';
%     outStr = '';
% for l = tStr
%     if (length(find(special == l)) > 0)
%         outStr = [outStr, '\', l];
%     else
%         outStr = [outStr, l];
%     end
% end
%disp(pr);
%v = 'this is a test for efficiency...First i try these notorious character set ?<,!`¬\| ~''''][and then i make these UPPERCASE?/(making a truce)!! !12-90877-90876-98';
    [filename, pathname] = uiputfile('*.txt','Save as');
    fileID = fopen([pathname, filename],'w');
    fprintf(fileID,'%s',pr);
    msgbox('Save was succesfull', 'Status Message');
end


% --- Executes during object creation, after setting all properties.


% --- Executes on button press in pushbutton4.
function pushbutton4_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton4 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global mult;
global K;
global fcr;
mult = mult + 1;
axes(handles.axes1);
imshow(['found',num2str(mult),'.j2c']);
fcr  = imread(['found',num2str(mult),'.j2c']);
if K > mult
    set(handles.text5, 'visible', 'on');
    set(handles.pushbutton5, 'visible', 'on')
elseif isequal(K,mult)
    set(handles.text4, 'visible', 'off');
    set(handles.pushbutton4, 'visible', 'off')
    set(handles.text5, 'visible', 'on');
    set(handles.pushbutton5, 'visible', 'on')
end

% --- Executes on button press in pushbutton5.
function pushbutton5_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton5 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global mult;
global K;
global fcr;
mult = mult - 1;
axes(handles.axes1);
imshow(['found',num2str(mult),'.j2c']);
fcr  = imread(['found',num2str(mult),'.j2c']);
if K > mult
    if isequal(mult,1)
     set(handles.text4, 'visible', 'on');
    set(handles.pushbutton4, 'visible', 'on');
     set(handles.text5, 'visible', 'off');
    set(handles.pushbutton5, 'visible', 'off');
    else
        set(handles.text4, 'visible', 'on');
    set(handles.pushbutton4, 'visible', 'on');
     set(handles.text5, 'visible', 'on');
    set(handles.pushbutton5, 'visible', 'on');
    end
elseif isequal(mult,K)
    set(handles.text4, 'visible', 'on');
    set(handles.pushbutton4, 'visible', 'on')
     set(handles.text5, 'visible', 'off');
    set(handles.pushbutton5, 'visible', 'off')
end
