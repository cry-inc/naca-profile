NACA Profile Visialization Tool
===============================

![Screenshot](https://raw.github.com/cry-inc/naca-profile/master/screenshot.png)

This software uses the ALGLIB from http://www.alglib.net/ which is distributed under the GPL.

The tool can be configured with the two text files: profile.txt and probes.txt

profile.txt contains a set of points which represent the airfoil. Each line must contain two
values (x and y coordinates) seperated by a space character. The easiest way to generate such
a profile is a generator like this one: http://www.ppart.de/aerodynamics/profiles/NACA4.html.
The included profile contains a NACA 4415 profile polygon made out of 100 points.

The second file, probes.txt, contains the indicies of the points which represent the positions
of the attached measurement probes. The number and order of the probes are important.
The supplied data values must consist of the same number of measurement values.
Also, the values must be in the same order as the probes.

The data values for visialization can be supplied in two different ways:
- Via the text box in the UI (sepereated by spaces, newlines or semicolons)
- As UDP packets to port 10001, containing a ASCII string like described above

Example string for 4 probes: "0.99 -0.12 -0.44 0.76". Note that these example values are all
between -1 and 1. This is NOT necessary BUT you may have to scale the values for a better
presentation.