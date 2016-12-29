function varargout = Pixtool(varargin)
% PIXTOOL MATLAB code for Pixtool.fig
%      PIXTOOL, by itself, creates a new PIXTOOL or raises the existing
%      singleton*.
%
%      H = PIXTOOL returns the handle to a new PIXTOOL or the handle to
%      the existing singleton*.
%
%      PIXTOOL('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in PIXTOOL.M with the given input arguments.
%
%      PIXTOOL('Property','Value',...) creates a new PIXTOOL or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before Pixtool_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to Pixtool_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help Pixtool

% Last Modified by GUIDE v2.5 27-Mar-2015 17:24:51

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @Pixtool_OpeningFcn, ...
                   'gui_OutputFcn',  @Pixtool_OutputFcn, ...
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
%guidata(hObject, handles);
%axes(handles.axes1);
%imshow('temp.png');

% End initialization code - DO NOT EDIT


% --- Executes just before Pixtool is made visible.
function Pixtool_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to Pixtool (see VARARGIN)

% Choose default command line output for Pixtool
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);
axes(handles.axes1);
imshow('temp.j2c');

% UIWAIT makes Pixtool wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = Pixtool_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;
axes(handles.axes1);
imshow('temp.j2c');



% --------------------------------------------------------------------
function uipushtool1_ClickedCallback(hObject, eventdata, handles)
% hObject    handle to uipushtool1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
[~, st] = imsave();
if st < 1
    msgbox('Save was succesfull', 'Status Message');
else
    msgbox('Save cancelled by user', 'Status Message');
end


% --- Executes during object creation, after setting all properties.
function axes1_CreateFcn(hObject, eventdata, handles)
% hObject    handle to axes1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: place code in OpeningFcn to populate axes1
