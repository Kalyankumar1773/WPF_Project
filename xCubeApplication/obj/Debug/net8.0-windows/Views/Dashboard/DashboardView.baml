   M S B A M L   `   `   `  ����K  GxCubeApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:xCubeApplication.Views.Dashboard xCubeApplication.Views.Dashboard  5      ]3clr-namespace:xCubeApplication.ViewModels.Dashboard%xCubeApplication.ViewModels.Dashboard  5      4    .xCubeApplication.Views.Dashboard.DashboardView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:xCubeApplication.Views.Dashboard     5      Flocal13clr-namespace:xCubeApplication.ViewModels.Dashboard     5        � DataContext  5
      >   8xCubeApplication.ViewModels.Dashboard.DashboardViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � -   5         �Name$ 	sidePanel��5      ���	#FF0F4E7A$
��Left=�69   $	��150��6T   .+�5      �� .+�5      � $��30��6   ���	#FF0F4E7A.+�5      �� -   5        $��Right=�5      $��20��69   $	��Top=�6E   
������ 
������ .��5      �� $��/Images/menu.png��6    5      5      �� 5      $��Disabled=�6   $��Century Gothic)�6Q   $��14(�6m   
�������
������ 
������ $
��Bold"�6�   .@�5      �� $��30��6#   .��5      �� -   5         ��Name$ 
btnAddUser��5   !   $	��135��65   ���	#FF0F4E7A��6X   �� *ShowAddUserViewCommand+.��5       ��  �� Orientation$ 
Horizontal=�6)   .+�5!   "   �� $��/Images/AddUser.png��6(   $��20��6E   $��Center=�6Q   �� 5"   "   $��10 0 0 0q�6,   
�������$��Add New User��6Q   $��Center=�6e   5#      5$      5%      �� 5&      $��30��6#   .��5'      �� -   5        $ btnAllUsers��5'   !   $	��135��66   ���	#FF0F4E7A��6Y   �� *ShowAllUsersViewCommand+.��5(      �� $ 
Horizontal=�6)   .+�5)   "   �� $��/Images/users.png��6(   $��20��6C   $��Center=�6O   �� 5*   "   $��15 0 0 0q�6,   
�������$��	All Users��6Q   $��Center=�6b   5+      5,      5-      �� 5.      $��30��6#   .��5/      �� -   5        $ btnmap��5/   !   $	��135��61   ���	#FF0F4E7A��6T   �� *ShowMapViewCommand+.��50      �� $ 
Horizontal=�6)   .+�51   "   �� $��/Images/map.png��6(   $��20��6A   $��Center=�6M   �� 52   "   $��15 0 0 0q�6,   
�������$��Map View��6Q   $��Center=�6a   53      54      55      56      57      58      � 59   
   $��1��6   
�������$��10q�62   .+�5:      �� ��6   �� *CurrentViewModel+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� � 	Resources 5;       �� DataType<   6xCubeApplication.ViewModels.Dashboard.AddUserViewModel2   ,xCubeApplication.Views.Dashboard.AddUserView=   7xCubeApplication.ViewModels.Dashboard.AllUsersViewModel3   -xCubeApplication.Views.Dashboard.AllUsersView8   2xCubeApplication.ViewModels.Dashboard.MapViewModel.   (xCubeApplication.Views.Dashboard.MapView��%�   (��       5<   $   *, +)(�� 2     5?   $   *, +)(�� d     5B   $   *, +)�� 5<      "  6$   .R�5=        5>      �� 5?      "  6$   .R�5@        5A      �� 5B      "  6$   .R�5C        5D      5E      5F      5G      5H      5I      