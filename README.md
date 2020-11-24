# Xamarin.FinalCtrl

Simple and slim controls designed for easy use

![Nuget](https://img.shields.io/nuget/v/Xamarin.FinalCtrl?style=plastic)


####TabView

- Get the Namespace:
```xml
    xmlns:ctrl="clr-namespace:Xamarin.FinalCtrl.TabViewCtrl;assembly=Xamarin.FinalCtrl"
```

- Create the Control:

```xml
    <ctrl:TabView
        ContentTemplateSelector="{StaticResource MainViewTemplateSelector}"
        Itemssource="{Binding Items}"
        TabPosition="Bottom">
        <ctrl:TabView.TabTemplate>
            <DataTemplate>
                <StackLayout HorizontalOptions="Center" Orientation="Horizontal">
                    <Label Text="{Binding Index}" TextColor="Black" />
                    <Label
                        IsVisible="{Binding IsSelected}"
                        Text="!!!"
                        TextColor="Black" />
                </StackLayout>
            </DataTemplate>
        </ctrl:TabView.TabTemplate>
    </ctrl:TabView>
```
####Properties:
- ContentTemplateSelector: Selectes the Template for your Tab
- Itemssource: The list of Tabs(ViewModels) you want to use
- TabPosition: You want the Tabs on the Top or Bottom?
- TabTemplate: The Template for the individual Tabs.

**Note:** If your Items implement *ITabItem*  you can access the *IsSelected* property in your bindings (See TabTemplate above).


Feel free to submit improvements or file Issues/Pull requests, but keep in mind: 
This controls aim to be as simple as possible.



