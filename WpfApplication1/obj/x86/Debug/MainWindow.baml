   M S B A M L   `   `   `  ����  WpfApplication1     WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��768��6   $
��1024��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5
   
   �� -   5         ��Name$ FileTextBox��5
      $	��450��6'   $��30��63   $
��Left=�6?   $��10q�6Z   ��6f   �� *
FilePath+�� 5   
   -   5         ��Name$ OpenFileButton��5      $��50��6)   $��30��64   $
��Left=�6@   $��	480 0 0 0q�6[   $��参照��6n   ��6{   �� *OpenFileCommand+�� 5   
   -   5         ��Name$ EncodingComboBox��5      $	��200��6-   $��30��69   $��Right=�6E   $��	0 0 100 0q�6a    �� DisplayMemberPath$ EncodingName��5      ��5      �� *EncodingList+ �� SelectedValue 68   �� *FileEncoding+5      �� 5   
   -   5        $ ExecuteButton��5      $��50��6(   $��30��63   $��実行��6?   $��Right=�6L   $��10q�6h   ��6t   �� *ReadFileCommand+��5      ��  �� ElementName$ FileTextBox�� �� Path$
 Text�� 5   
   $��1��6   	 � ColumnDefinitions	 5      �� 5      $��* �6#   �� 5      $��5 �6#   �� 5      $��* �6#   .+�5      �� -   5        
 ��Name$
 TextListView��5      ��6.   �� *Text+5      �� 5      -   5         ��Name$ Splitter��5      $��1��6-   $��Stretch=�6=   �� 5      -   5        $
 HexTextListView��5      $��2��60   ��6@   �� *	HexText+5      5      5      5      