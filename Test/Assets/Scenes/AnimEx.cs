using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.cupertino;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace UIWidgetsSample
{
    public class AnimEx : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            FontManager.instance.addFont(Resources.Load<Font>(path: "MaterialIcons-Regular"), "Material Icons");
            base.OnEnable();
        }

        protected override Widget createWidget()
        {
            return new WidgetsApp(
                home: new ExampleApp(),
                pageRouteBuilder: (RouteSettings settings, WidgetBuilder builder) =>
                    new PageRouteBuilder(
                        settings: settings,
                        pageBuilder: (BuildContext context, Animation<float> animation,
                            Animation<float> secondaryAnimation) => builder(context)
                    )
            );
        }

        class ExampleApp : StatefulWidget
        {
            public ExampleApp(Key key = null) : base(key)
            {
            }

            public override State createState()
            {
                return new ExampleState();
            }
        }

        class ExampleState : State<ExampleApp>
        {
            //IconData iconData = Unity.UIWidgets.material.Icons.menu;
            //Curve switchCurve = new Interval(0.4f, 1.0f, curve: Curves.fastOutSlowIn);
            TextAnim textAnim = new TextAnim();
            public override Widget build(BuildContext context)
            {
                return new Column(
                    children: new List<Widget> {
                        ////切换动画
                        //new AnimatedSwitcher(
                        //    duration: new System.TimeSpan(0, 0, 1),
                        //    switchInCurve: switchCurve,
                        //    switchOutCurve: switchCurve,
                        //    child: new IconButton(
                        //        //不同的key才会认为是不同的组件，否则不会执行动画
                        //        key: new ValueKey<IconData>(iconData),
                        //        icon: new Icon(icon :iconData, color: Colors.white),
                        //        onPressed: () => {
                        //            this.setState(() => {
                        //                if (iconData.Equals(Unity.UIWidgets.material.Icons.menu))
                        //                {
                        //                    iconData = Unity.UIWidgets.material.Icons.close;
                        //                }
                        //                else
                        //                {
                        //                    iconData = Unity.UIWidgets.material.Icons.menu;

                        //                }
                        //            });
                        //        }
                        //    )
                        //),
                        new CupertinoButton(onPressed: () => { textAnim.controller.forward(); },
                            child: new Text("Go"),
                            color:CupertinoColors.activeBlue
                        ),
                        textAnim.build(context)
                    }
                   );
            }
        }

        private class TextAnim : SingleTickerProviderStateMixin<ExampleApp>
        {
            public AnimationController controller = null;
            public override Widget build(BuildContext context)
            {
                controller = new AnimationController(duration: new System.TimeSpan(0, 0, 2), vsync: this);
                controller.addStatusListener((status) => {
                    if(status == AnimationStatus.completed)
                    {
                        controller.reset();
                    }
                });
                Animation<Offset> offset = controller.drive(new OffsetTween(
                    begin: Offset.zero,
                    end: new Offset(0.0f, 2f)
                ));
                return new SlideTransition(
                            position: offset,
                            child: Unity.UIWidgets.widgets.Image.asset(
                                name: "test",
                                height: 100
                            )
                        );
            }
        }
    }

}