function varargout = enKrypt(varargin)
% ENKRYPT MATLAB code for enKrypt.fig
%      ENKRYPT, by itself, creates a new ENKRYPT or raises the existing
%      singleton*.
%
%      H = ENKRYPT returns the handle to a new ENKRYPT or the handle to
%      the existing singleton*.
%
%      ENKRYPT('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in ENKRYPT.M with the given input arguments.
%
%      ENKRYPT('Property','Value',...) creates a new ENKRYPT or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before enKrypt_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to enKrypt_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help enKrypt

% Last Modified by GUIDE v2.5 17-Mar-2015 22:37:10

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @enKrypt_OpeningFcn, ...
                   'gui_OutputFcn',  @enKrypt_OutputFcn, ...
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


% --- Executes just before enKrypt is made visible.
function enKrypt_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to enKrypt (see VARARGIN)

% Choose default command line output for enKrypt
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);
javaFrame = get(hObject,'JavaFrame');
javaFrame.setFigureIcon(javax.swing.ImageIcon('text.png'));


% UIWAIT makes enKrypt wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = enKrypt_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --- Executes on button press in radiobutton1.
function radiobutton1_Callback(hObject, eventdata, handles)
% hObject    handle to radiobutton1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of radiobutton1


% --- Executes on button press in radiobutton11.
function radiobutton11_Callback(hObject, eventdata, handles)
% hObject    handle to radiobutton11 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of radiobutton11


% --- Executes on button press in radiobutton10.
function radiobutton10_Callback(hObject, eventdata, handles)
% hObject    handle to radiobutton10 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of radiobutton10


% --- Executes on button press in radiobutton8.
function radiobutton8_Callback(hObject, eventdata, handles)
% hObject    handle to radiobutton8 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of radiobutton8


% --- Executes on button press in radiobutton7.
function radiobutton7_Callback(hObject, eventdata, handles)
% hObject    handle to radiobutton7 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of radiobutton7

function uipanel11_SelectionChangeFcn(hObject, eventdata, handles)
% hObject    handle to uipanel11 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called
global selval;
switch get(eventdata.NewValue,'Tag') % Get Tag of selected object.
    case 'radiobutton11'
        % Code for when radiobutton1 is selected.
        selval = 1;
       % disp('lop');
    case 'radiobutton7'
        % Code for when radiobutton2 is selected.
        selval = 2;
       % disp('lop2');
    case 'radiobutton8'
        % Code for when togglebutton1 is selected.
        selval = 3;
       % disp('lop3');
    case 'radiobutton10'
        % Code for when togglebutton2 is selected.
        selval = 4;
       % disp('lop4');
    % Continue with more cases as necessary.
    otherwise
        % Code for when there is no match.
        selval = 1;
end

% --- Executes on button press in pushbutton1.
function pushbutton1_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global pixtext;
global selval;
pixtext = importdata('pixelate.txt', ' ');
swapdat = newKrp(pixtext);
%disp(selval);
if selval > 1
    incomin = inflate(swapdat, selval);
else
    incomin = swapdat;
end
%[fn, pn] = uiputfile('*.png','Save as');
 %  fid = fopen([pn, fn],'w');
 %   imwrite(incomin,[pn,fn]);
 imwrite(incomin, 'temp.j2c');
%  axes(handles.axes1);
%  imshow('temp.png');
%  [fn, st] = imsave();
%  delete('temp.png');
%  msgbox('Save was succesfull', 'Status Message');
% --- Executes during object creation, after setting all properties.
%open('Pixtool.fig');
Pixtool


% --- Executes during object creation, after setting all properties.
function uipanel11_CreateFcn(hObject, eventdata, handles)
% hObject    handle to uipanel11 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called


% --------------------------------------------------------------------
function Untitled_1_Callback(hObject, eventdata, handles)
% hObject    handle to Untitled_1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
