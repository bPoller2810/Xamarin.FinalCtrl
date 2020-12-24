# Xamarin.FinalCtrl

Simple and slim controls designed for easy use

![Nuget](https://img.shields.io/nuget/v/Xamarin.FinalCtrl?style=plastic)

## Getting Started:
- Install [the latest NuGet](https://www.nuget.org/packages/Xamarin.FinalCtrl/1.2.0) in your Project
- Grab the Namespace like this:
```xml
    xmlns:ctrl="clr-namespace:Xamarin.FinalCtrl.TabViewCtrl;assembly=Xamarin.FinalCtrl"
```
- Ready to go !

## TintableImage
```xml
<ctrl:TintableImage Source="image.png"
                    TintColor="Red" />
```
#### Properties:
 - TintColor: Colors the Image in the specified Color

## Toolbar:
```xml
<ctrl:Toolbar Text="{Binding SelectedItem.Title}"
              BackgroundColor="{StaticResource LightGray}"
              RightCommand="{Binding RightIconCommand}"
              FontFamily="Lora"
              FontSize="24"
              TextColor="Black">
    <ctrl:Toolbar.RightContent>
        <Image Source="{Binding Icon}" />
    </ctrl:Toolbar.RightContent>
</ctrl:Toolbar>
```
#### Properties
- Text: Centralized Text
- TextColor: The color of your Text
- FonzSize: The size of your Text
- FontFamily: The font of your Text
- Left/Right-Content: The contents used to display any kind of UI as your Icon
- Left/Right-Command: The commands invoked on a Tab on your left or right UI
- Left/Right-CommandParameter: All types of objects attached to the execution of your command

## TabView:
```xml
<ctrl:TabView
    ContentSelector="{StaticResource MainViewSelector}"
    Itemssource="{Binding Items}"
    TabPosition="Bottom">
    <ctrl:TabView.TabContent>
        <ControlTemplate>
            <StackLayout HorizontalOptions="Center" Orientation="Horizontal">
                <Label Text="{Binding Index}" TextColor="Black" />
                <Label
                    IsVisible="{Binding IsSelected}"
                    Text="!!!"
                    TextColor="Black" />
            </StackLayout>
        </ControlTemplate>
    </ctrl:TabView.TabTemplate>
</ctrl:TabView>
```
#### Properties:
- ContentSelector (IContentSelector): Selects the Content for your Tab (This creates a new Instance each time)
- Itemssource: The list of Tabs(ViewModels) you want to use
- TabPosition: You want the Tabs on the Top or Bottom?
- TabContent: The ControlTemplate for the individual Tabs.

**Note:** If your Items implement *ITabItem*  you can access the *IsSelected* property in your bindings (See TabTemplate above).

------------

**Helpfull:** Check out the Sample Project! MainPage.xaml should lead you to all places you need

------------
Feel free to submit improvements or file Issues/Pull requests, but keep in mind: 
This controls aim to be as simple as possible.


#### Versions:
- 1.0.0: Initial TabControl
- 1.1.0: Reworked TabControl
- 1.2.0: Toolbar
