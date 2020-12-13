# Xamarin.FinalCtrl

Simple and slim controls designed for easy use

![Nuget](https://img.shields.io/nuget/v/Xamarin.FinalCtrl?style=plastic)


## TabView

- Get the Namespace:
```xml
    xmlns:ctrl="clr-namespace:Xamarin.FinalCtrl.TabViewCtrl;assembly=Xamarin.FinalCtrl"
```

- Create the Control:

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

### Properties:
- ContentSelector (IContentSelector): Selects the Content for your Tab (This creates a new Instance each time)
- Itemssource: The list of Tabs(ViewModels) you want to use
- TabPosition: You want the Tabs on the Top or Bottom?
- TabContent: The ControlTemplate for the individual Tabs.

**Note:** If your Items implement *ITabItem*  you can access the *IsSelected* property in your bindings (See TabTemplate above).

------------
Feel free to submit improvements or file Issues/Pull requests, but keep in mind: 
This controls aim to be as simple as possible.



