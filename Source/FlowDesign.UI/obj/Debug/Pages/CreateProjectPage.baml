   M S B A M L   `   `   `  ����H  DFlowDesign.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:FlowDesign.UI.ValueConverterFlowDesign.UI.ValueConverter  5      9!clr-namespace:FlowDesign.UI.PagesFlowDesign.UI.Pages  5      S.clr-namespace:FlowDesign.UI.Controls.Seperator FlowDesign.UI.Controls.Seperator  5      C&clr-namespace:FlowDesign.UI.ViewModelsFlowDesign.UI.ViewModels  5	      +    %FlowDesign.UI.Pages.CreateProjectPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @	converter*clr-namespace:FlowDesign.UI.ValueConverter     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:FlowDesign.UI.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      E
seperators.clr-namespace:FlowDesign.UI.Controls.Seperator     5      =
viewModels&clr-namespace:FlowDesign.UI.ViewModels     5	        N� Title$  CreateProjectPage��5
      $��	50 50 0 0q�5      $
��Left=�5       � DataContext 5      5   /FlowDesign.UI.ViewModels.CreateProjectViewModel  5   
   .��5      �  � 	Resources 5   
   6   0FlowDesign.UI.ValueConverter.MultibindingToArray   mulitbindingConverter��%   &	          5      6,   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��30 �6    � ColumnDefinitions 5    
   �� 5!      �� 5"      �� 5#      $
��auto �6   .+�5&   
   �� $��0��6   $��2��5'      $��0 0 0 30q�5(      $
��Left=�5)      $��40(�5*      $
��Bold"�5+        TextHeading#���  5,      $��Projekt Erstellen��5-      �� 5/   
   $��1��6   $��0��50      $��Center=�51      $��14(�52        TextBody#���  53      $��Name:��54      �� 56   
   -   5         ��Name$ nameTextBox��56      $��1��57      $��1��58      $	��300��59      $��30��5:      $��10 0 0 0q�5;      ��5<      �� *ProjectName+�� 5=   
   $��2��6   $��0��5>      $��Center=�5?      $��14(�5@      #���  5A      $��Speicherort:��5B      �� 5C   
   -   5        $ speicherortTextBox��5C      $��2��5D      $��1��5E      $	��300��5F      $��30��5G      $��10 0 0 0q�5H      ��5I      �� *ProjectFilepath+�� 5K   
   -   5        $��2��5K      $��2��5L      $	��125��5M      $��30��5N      $��15 2 0 2q�5O      $��durchsuchen��5Q      �� 5S   
   $��3��6   $��1��5T      $��2��5U       �� Orientation$ 
Horizontal=�5V      .+�5W      �� $	��125��6   $��30��5X      $��10 2 0 2q�5Y      $��	erstellen��5[      ��5Z      �� *CreateProjectCommand+5[      �� 5\      -   5        $	��125��5\      $��30��5]      $��15 2 0 2q�5^      $��	abbrechen��5`      5a      5e      5f      