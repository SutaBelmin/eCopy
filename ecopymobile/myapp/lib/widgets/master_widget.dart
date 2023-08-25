import 'package:flutter/material.dart';

import 'package:myapp/screens/print_list_screen.dart';
import 'package:myapp/screens/account_screen.dart';

class MasterWidget extends StatefulWidget {
  Widget? child;
  int? selectedIndex = 0;
  MasterWidget({this.child, this.selectedIndex, Key? key}) : super(key: key);

  @override
  State<MasterWidget> createState() => _MasterWidgetState();
}

class _MasterWidgetState extends State<MasterWidget> {
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
  }

  void _onItemTapped(int index) {
    setState(() {
      widget.selectedIndex = index;
    });
    if (widget.selectedIndex == 0) {
      Navigator.popAndPushNamed(context, PrintListScreen.rotueName);
    } else if (widget.selectedIndex == 1) {
      Navigator.popAndPushNamed(context, AccountScreen.routeName);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(child: widget.child!),
      bottomNavigationBar: _buildBottomNavigationBar(widget.selectedIndex!),
    );
  }

  Widget _buildBottomNavigationBar(int selectedIndex) {
    return BottomNavigationBar(
      items: const <BottomNavigationBarItem>[
        BottomNavigationBarItem(
          backgroundColor: Color.fromARGB(195, 31, 173, 238),
          icon: Icon(Icons.home_rounded),
          label: 'Home',
        ),
        BottomNavigationBarItem(
          backgroundColor: Color.fromARGB(195, 31, 173, 238),
          icon: Icon(Icons.account_circle_rounded),
          label: 'Profile',
        )
      ],
      currentIndex: selectedIndex,
      selectedItemColor: Color.fromARGB(255, 65, 108, 235),
      onTap: _onItemTapped,
    );
  }
}
