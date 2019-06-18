{\rtf1\ansi\ansicpg1252\cocoartf1671\cocoasubrtf500
{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;\red0\green0\blue233;\red63\green63\blue63;\red255\green255\blue255;
\red255\green255\blue255;\red63\green63\blue63;\red63\green63\blue63;\red63\green63\blue63;\red63\green63\blue63;
\red0\green0\blue0;\red63\green63\blue63;}
{\*\expandedcolortbl;;\cssrgb\c0\c0\c93333;\cssrgb\c31373\c31373\c31373;\cssrgb\c100000\c100000\c100000;
\cssrgb\c100000\c100000\c100000\c0;\cssrgb\c31407\c31407\c31368;\cssrgb\c31476\c31476\c31358;\cssrgb\c31442\c31442\c31363;\cssrgb\c31510\c31510\c31353;
\cssrgb\c0\c1\c1;\cssrgb\c31678\c31676\c31322;}
\paperw11900\paperh16840\margl1440\margr1440\vieww10800\viewh8400\viewkind0
\pard\tx720\tx1440\tx2160\tx2880\tx3600\tx4320\tx5040\tx5760\tx6480\tx7200\tx7920\tx8640\pardirnatural\partightenfactor0

\f0\fs24 \cf0 Readme doc for SuperHeroes solution\
\
Points to note:\
\
The solution is written in .Net core 2.2 sdk\
can be downloaded from here if needed\
\pard\pardeftab720\sl280\partightenfactor0
{\field{\*\fldinst{HYPERLINK "https://dotnet.microsoft.com/download/archives"}}{\fldrslt \cf2 \expnd0\expndtw0\kerning0
\ul \ulc2 \outl0\strokewidth0 \strokec2 https://dotnet.microsoft.com/download/archives}}\
\pard\tx720\tx1440\tx2160\tx2880\tx3600\tx4320\tx5040\tx5760\tx6480\tx7200\tx7920\tx8640\pardirnatural\partightenfactor0
\cf0 \
The api endpoint is \cf3 \cb4 \expnd0\expndtw0\kerning0
\outl0\strokewidth0 \strokec3 https://localhost:5001/api/superheroes\cf0 \cb1 \kerning1\expnd0\expndtw0 \outl0\strokewidth0 \
\
\cb5 This will return XML or JSON formatted response depending on  the Accept attribute specified in the Header of the request call ie. Accept : \cf6 \cb5 \expnd0\expndtw0\kerning0
\outl0\strokewidth0 \strokec6 a\cf7 \cb5 \strokec7 pplication/xml\cf8 \cb5 \strokec8 \
\cf9 \cb5 \strokec9 \
\cf10 \cb5 \strokec11 An object of type Character is returned which has a list of associated Villains and Superheroes\
\
}