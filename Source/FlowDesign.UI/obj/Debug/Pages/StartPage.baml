   M S B A M L   `   `   `  ����H  DFlowDesign.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:FlowDesign.UI.Controls.ButtonsFlowDesign.UI.Controls.Buttons  5      9!clr-namespace:FlowDesign.UI.PagesFlowDesign.UI.Pages  5      K GFlowDesign.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:FlowDesign.Model;assembly=FlowDesign.ModelFlowDesign.Model 5      S.clr-namespace:FlowDesign.UI.Controls.Seperator FlowDesign.UI.Controls.Seperator  5	      C&clr-namespace:FlowDesign.UI.ViewModelsFlowDesign.UI.ViewModels  5
      #    FlowDesign.UI.Pages.StartPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @buttons,clr-namespace:FlowDesign.UI.Controls.Buttons     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:FlowDesign.UI.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Kmodels8clr-namespace:FlowDesign.Model;assembly=FlowDesign.Model     5      E
seperators.clr-namespace:FlowDesign.UI.Controls.Seperator     5	      =
viewModels&clr-namespace:FlowDesign.UI.ViewModels     5
        N� Title$  	StartPage��5       � DataContext 5      1   +FlowDesign.UI.ViewModels.StartPageViewModel  5   
   .��5      ]� .+�5   
   �� $	��300��6      DarkBackground#���   5      $
��Left=�5      .+�5      �� $��20q�6   $��Center=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� $��80��6   $��80��5       �� BitmapScalingMode$
 Fant=�5      $,��&../Resources/Images/Logos/flowLogo.png��5      $��UniformToFill=�5      �� 5       $��10 0 0 0q�6   $��Center=�5!      $��26(�5"        TextHeading#���  5#      �� 6H   $
�FLOW��6L   �� 5$      �� 6#   $�DESIGN��6'   69   5%      5   /FlowDesign.UI.Controls.Seperator.InsetSeperator  5'      $��	10 0 10 0q�6(     DarkBackgroundFill   DarkPartBackground# �  5(   (      DarkPartHeight$ 2��5)   (     DarkBackgroundLightFill   LightPartBackground# �  5*   (   � 5-      $��	0 10 0 10q�6   .+�5.      �� .+�5/      �� $��30 0 0 0q�6    $��16(�50       $
��Bold"�51       #���  52       $��Starten��53       0   *FlowDesign.UI.Controls.Buttons.ImageButton  54      0   *FlowDesign.UI.Controls.Buttons.ImageButton   Click$ NewProjectButton_Clicked��55   *     Main   BorderHighlightedColor# �  54   *   $��NEUES PROJEKT��56   *   	   ContentMargin$	 30 5 0 5q�57   *   $
��Bold"�58   *   #���  59   *     Highlighted
   HighlightedColor#
 �  5:   *     IconNewProject   
IconSource# �  5;   *      
TextMargin$ 20 0 0 0q�5<   *     5=      $ LoadProjectButton_Clicked��5>   *   # �  5=   *   $��PROJEKT ÖFFNEN��5?   *   $	 30 5 0 5q�5@   *   $
��Bold"�5A   *   #���  5B   *   #
 �  5C   *     IconOpenProject# �  5D   *   $ 20 0 0 0q�5E   *   5G      5H        5J      $��	10 0 10 0q�6(   # �  5K   (   $ 2��5L   (   # �  5M   (   �� 5O      $��	30 10 0 0q�6   $��16(�5P      $
��Bold"�5Q      #���  5R      $��Zuletzt��5S      �� 5W      ��6   �� *RecentlyOpenedProjects+��5X      �� 5Y      .R�5Z      �� $��	0 10 0 10q�6%   $ Vertical=�68    � 	Resources 5[       �� DataType*  $FlowDesign.Model.RecentlyUsedProject �� RelativeSource �� AncestorType��%�  (��       5\   /   *, +)�� 6"   "  6/   .R�5]   &     # �  6:   $	 30 5 0 5q�5c   :   $��14(�5d   :   $
��Bold"�5e   :   #���  5f   :   #
 �  5g   :   $2 ,../Resources/Images/Logos/flowLogo_Small.png��5h   :   $ 20 0 0 0q�5i   :   ��5^   :   �� * DataContext.LoadProjectCommand+ �� *FindAncestor+" ����5a   :   �� *
Filepath+��5b   :   �� *Name+5i   :   5j   #   5k      5l      5m      5o      5p      �� 5r   
   $��2��6   $
��Left=�5s      #���  5t       � 5v   
   -   5          �Name$ startPageFrame��5v      #���   5w      $��Right=�5x        � NavigationUIVisibility$ Hidden=�5y      5|      5}      