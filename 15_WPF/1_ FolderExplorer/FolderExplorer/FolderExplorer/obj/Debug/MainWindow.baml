   M S B A M L   `   `   `  ����I  EFolderExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FolderExplorerFolderExplorer  5   	   /clr-namespace:FolderExplorerFolderExplorer  5   	       FolderExplorer.MainWindow   5   	   #myclr-namespace:FolderExplorer  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:FolderExplorer     5   	     � Title$  Folder Explorer��5	   	   $	��450��6!   $	��800��6.    � 	Resources 5
         RootFolderDataProvider S� ObjectInstance   FolderExplorer.Folder   FullPath �� DataType �� ItemsSource �� Path��%�   &	        (�� A     5      *, +)S� 5   
    5        5      $	 d:\��6   5      �� 5   
   "  5       5      �� $ 
SubFolders�.R�5      �� ��6   �� $
 Name�5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5       $��2* �6   .+�5"   
   R� -   5        $��	treeView1��5"   I   $��1��6   $��2��6'   $��0,0,0,0q�68   .@�5#      Q� $��Folders��6s   ��6   �� $ 
SubFolders�	 �� Source#	 [  6s   5$      �� 5&   
   -   5        $��	listView1��5&      $��1��5(      $��1��5)      ��5'      �� $ SelectedItem.SubFolders�
 �� ElementName$
 	treeView1�� �� Mode$ OneWay=�5)      �� 5+   
   -   5        $��	listView2��5+      $��1��5-      $��1��5.      ��5,      �� $ SelectedItem.Files�$
 	treeView1��$ OneWay=�5.      52      53      