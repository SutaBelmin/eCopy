import 'package:flutter/material.dart';

class TopNavigationBar extends StatefulWidget {
  Widget? child;
  TopNavigationBar({this.child, Key? key}) : super(key: key);

  @override
  State<TopNavigationBar> createState() => _TopNavigationBarState();
}

class _TopNavigationBarState extends State<TopNavigationBar> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.grey,
        title:
            Text('eCopy', style: TextStyle(fontSize: 40, color: Colors.black)),
        leading: IconButton(
          icon: Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
        toolbarHeight: 100,
      ),
      body: SafeArea(child: widget.child!),
    );
  }
}
