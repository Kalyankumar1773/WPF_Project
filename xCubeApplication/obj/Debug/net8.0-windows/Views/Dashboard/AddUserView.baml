   M S B A M L   `   `   `  ����K  GxCubeApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:xCubeApplication.Views.Dashboard xCubeApplication.Views.Dashboard  5      ]3clr-namespace:xCubeApplication.ViewModels.Dashboard%xCubeApplication.ViewModels.Dashboard  5      2    ,xCubeApplication.Views.Dashboard.AddUserView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:xCubeApplication.Views.Dashboard     5      Flocal13clr-namespace:xCubeApplication.ViewModels.Dashboard     5        � DataContext  5      <   6xCubeApplication.ViewModels.Dashboard.AddUserViewModel  5   
   .��5      � $��20q�6   ���#FFFFFF � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��10q�6   $��User Details��6    $
��Bold"�64   $��18(�6F   ���	#FF0F4E7A6T   �� 5   
   $��1��6   $��10q�6$   .��5      �� .+�5      �� .+�5      �� $
��Name��6    $��5q�6,   $
��Bold"�67   $��12(�6I   ���	#FF0F4E7A6W   �� 5      $��5q�64   $��35��6?   $��7q�6K   ��6   �� *Name+6K   5      �� 5      .+�5       �� $	��Age��6    $��5q�6+   $
��Bold"�66   $��12(�6H   ���	#FF0F4E7A6V   �� 5!      $��5q�6e   $��35��6p   $��10q�6|   ��6   �� *Age+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6|   5"      �� 5$      .+�5%      �� $��Date of Birth��6    $��5q�65   $
��Bold"�6@   $��12(�6R   ���	#FF0F4E7A6`   (  "System.Windows.Controls.DatePicker  5&      $��5q�6F   $��35��6Q      SelectedDate 6!   �� *DateOfBirth+6Q   5'      �� 5)      .+�5*      �� $��Contact Number��6    $��5q�66   $
��Bold"�6A   $��12(�6S   ���	#FF0F4E7A6a   �� 5+       �� 	MaxLength$ 10��6   $��5q�6~   $��35��6�   $��10q�6�   ��6-   �� *ContactNumber+$ PropertyChanged=�$ TwoWay=�6�   5,      �� 5.      .+�5/      �� $��Profile Picture��6    $��5q�67   $
��Bold"�6B   $��12(�6T   ���	#FF0F4E7A6b   �� 50       �� Orientation$ 
Horizontal=�6!   $��5q�6:   .+�51      �� $	��100��6r   $	��100��6   $��0,0,10,0q�6�   ��6    �� *ProfilePicture+$ PropertyChanged=�$ TwoWay=�6�   �� 52      $��Upload Picture��6!   $	��120��6c   $��35��6o   ���	#FF0F4E7A
���������6:   �� *UploadPictureCommand+6�   53      54      55      56      �� 58   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��5q�6W   .+�59      �� $
��Save��6   $��5q�6D   $��80��6O   $��35��6Z   ���	#FF0F4E7A
���������6$   �� *SaveCommand+6}   �� 5:      $��Cancel��6   $��5q�6H   $��80��6S   $��35��6^   
����������	#FF0F4E7A��6&   �� *CancelCommand+6}   5;      5<      5=      