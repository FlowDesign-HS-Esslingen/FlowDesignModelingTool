   M S B A M L   `   `   `  ����H  DFlowDesign.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FlowDesign.UIFlowDesign.UI  5   	   &     FlowDesign.UI.Windows.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -localclr-namespace:FlowDesign.UI     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Flow Design��5   	   $
��1024��5   	   $	��768��5	   	    � Icon$2 ,../Resources/Images/Logos/flowLogo_Small.png��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	   .��5      ]� ��. .+�5   
   `�    Info `� 
Background# �   6   $	��Top=�6:   .�5      c� $��30��6   .@�5      �� -   5        $��10,0,0,0q�5       � ToolTip$ Neues Projekt erstellen��5      .��5      ��  �� BitmapScalingMode$
 Fant=�6   $(��"../Resources/Icons/BnewProject.png��6C   5      �� 5       -   5        $��10,0,0,0q�5       $ Projekt öffnen��5"      .��5#      �� $
 Fant=�6   $)��#../Resources/Icons/BopenProject.png��6C   5$      �� 5%      -   5        $��10,0,0,0q�5%      $ 	Speichern��5'      .��5(      �� $
 Fant=�6   $#��../Resources/Icons/Bsave2.png��6C   5)      5+      c� 5-      $��Right=�6   .@�5.      �� 
������  �� Padding$ 5q�65   
Farbschema6M   	� 50      -   5         	� 	GroupName$ 
ColorTheme��51      $" Wechseln zur dunklen Ansicht��52      .��53      �� $��20��6   $
 Fant=�54      $*��$../Resources/Icons/PaletteDunkel.png��55      56      �� 58      	� 59      -   5        $ 
ColorTheme��5:      $! Wechseln zur hellen Ansicht��5;      .��5<      �� $��20��6   $
 Fant=�5=      $(��"../Resources/Icons/PaletteHell.png��5>      5@      5C      5D      �� 5F   
   $��2��6   $	��Top=�5G      
���   �5H      �� 5I   
   -   5        	 ��Name$	 	statusBar��5I      #���   5J      $��Bottom=�5K      .@�5L      �� -   5        
 ��Name$
 
statusItem��5L      $��Bereit��60   5M       � 5O   
   -   5          �Name$ 	mainFrame��5O      $��Stretch=�5P      $	��Top=�5Q        � NavigationUIVisibility$ Hidden=�5R      5S      5T      