   M S B A M L   `   `   `  ���� H  DFlowDesign.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:FlowDesign.UI.Controls.ButtonsFlowDesign.UI.Controls.Buttons  9!clr-namespace:FlowDesign.UI.PagesFlowDesign.UI.Pages  K GFlowDesign.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:FlowDesign.Model;assembly=FlowDesign.ModelFlowDesign.Model S.clr-namespace:FlowDesign.UI.Controls.Seperator FlowDesign.UI.Controls.Seperator  C&clr-namespace:FlowDesign.UI.ViewModelsFlowDesign.UI.ViewModels  #    FlowDesign.UI.Pages.StartPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @buttons,clr-namespace:FlowDesign.UI.Controls.Buttons     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:FlowDesign.UI.Pages     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Kmodels8clr-namespace:FlowDesign.Model;assembly=FlowDesign.Model     E
seperators.clr-namespace:FlowDesign.UI.Controls.Seperator     =
viewModels&clr-namespace:FlowDesign.UI.ViewModels       N� Title$  	StartPage�� � DataContext 1   +FlowDesign.UI.ViewModels.StartPageViewModel  .��]� .+��� $	��300��   DarkBackground#���   $
��Left=�.+��� $��20q�$��Center=� �� Orientation$ 
Horizontal=�.+��� $��80��$��80�� �� BitmapScalingMode$
 Fant=�$,��&../Resources/Images/Logos/flowLogo.png��$��UniformToFill=��� $��10 0 0 0q�$��Center=�$��26(�  TextHeading#���  �� $
�FLOW���� �� $�DESIGN��5   /FlowDesign.UI.Controls.Seperator.InsetSeperator  $��	10 0 10 0q�  DarkBackgroundFill   DarkPartBackground# �     DarkPartHeight$ 2��  DarkBackgroundLightFill   LightPartBackground# �  � $��	0 10 0 10q�.+��� .+��� $��30 0 0 0q�$��16(�$
��Bold"�#���  $��Starten��0   *FlowDesign.UI.Controls.Buttons.ImageButton  0   *FlowDesign.UI.Controls.Buttons.ImageButton   Click$ NewProjectButton_Clicked��  Main   BorderHighlightedColor# �  $��NEUES PROJEKT��	   ContentMargin$	 30 5 0 5q�$
��Bold"�#���    Highlighted
   HighlightedColor#
 �    IconNewProject   
IconSource# �     
TextMargin$ 20 0 0 0q�  $ LoadProjectButton_Clicked��# �  $��PROJEKT ÖFFNEN��$	 30 5 0 5q�$
��Bold"�#���  #
 �    IconOpenProject# �  $ 20 0 0 0q�  $��	10 0 10 0q�# �  $ 2��# �  �� $��	30 10 0 0q�$��16(�$
��Bold"�#���  $��Zuletzt���� ���� *RecentlyOpenedProjects+���� .R��� $��	0 10 0 10q�$ Vertical=� � 	Resources  �� DataType*  $FlowDesign.Model.RecentlyUsedProject �� RelativeSource �� AncestorType��%  (��       *, +)�� "  .R�  # �  $	 30 5 0 5q�$��14(�$
��Bold"�#���  #
 �  $2 ,../Resources/Images/Logos/flowLogo_Small.png��$ 20 0 0 0q����� * DataContext.LoadProjectCommand+ �� *FindAncestor+" ������ *
Filepath+���� *Name+�� $��2��$
��Left=�#���   � -     �Name$ startPageFrame��#���   $��Right=�  � NavigationUIVisibility$ Hidden=�