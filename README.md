# Spartcus

Spartacus program to generate datasets according to given constraints. 
Output sets in the form of spreadsheets can be used with machine learning algorithms (mostly mathematican programming models). Points are drawn using the [MersenneTwister](https://github.com/akiotakahashi/MersenneTwister) algorithm. The project is written using .Net Core and .Net Standard.

## Sample output
The sets are in the form of a list of points in the N dimensional space (X1-XN) together with a column representing the result (Y) that defines whether the point meets the restrictions.

| X1 | X2 | X3 | Y  |
|:--:|:--:|:--:|:--:|
| 10 | 15 | 12  | 0 |
| 0  | 8  | 6  | 1 |
| 2  | -8 | 12 | 0 |

Table: Sample output data

## Available predefined benchmarks:
+ Rectangle (2d)
+ DoubleRectangle (2d)
+ Circle (2d)
+ DoubleCircle (2d)
+ Simplex (not working yet) (2d)
+ Cube (not working yet) (3d)
+ DoubleCube (not working yet) (3d)
+ Ball (not working yet) (3d)
+ DoubleBall (not working yet) (3d)
+ Simplex (not working yet) (3d)

## How to use
Compile and run *dotnet Sparatus.dll*.

### Available parameters

TODO

### Sample
Invoke Spartacus to generate double circle (2d) datasets, output file doublecircle_5k.xlsx with 3 spreedsheet (learn_dataset, learn_validation_dataset, learn_dataset) every with 5000 points. 

`dotnet Spartacus.dll -b doublecircle -p 5000 --output doublecircle_5k --sheets learn_dataset learn_validation_dataset validation_dataset`

![DoubleCircleVisualization](/docs/images/sample_visualization.JPG)
Image: Visualization

## Contribution
Feel free to make pull request and add something or just create issue with question / suggestion for improvement / report bug.