# Spartcus

Spartacus program to generate datasets according to given constraints. 
Output sets in the form of spreadsheets can be used with machine learning algorithms (mostly mathematican programming models). Points are drawn using the [MersenneTwister](https://github.com/akiotakahashi/MersenneTwister) algorithm. The project is written using .Net Core and .Net Standard.

## Sample output
The sets are in the form of a list of points in the N dimensional space (X1-XN) together with a column representing the result (Y) that defines whether the point meets the restrictions.

| X1 | X2 | X3 | Y  |
|:--:|:--:|:--:|:--:|
| 10 | 15 | 12 | 0 |
| 0  | 8  | 6  | 1 |
| 2  | -8 | 12 | 0 |

Table: Sample output xlsx datasheet

## Available predefined benchmarks:
+ Cube
+ Ball
+ Simplex

### Rules for generating points

![Visualization](/docs/images/formulated_benchmarks.JPG)
Image: Benchmark formulated as MP models

### Available parameters

| Paramater | Description | Sample used | Required |
|:---------:|:-----------:|:-----------:|:--------:|
| --points  | Number of points to generate | --points 5000 | Yes |
| --outputpath  | Path to storage generated data| --outputpath C:\Desktop | Yes |
| --output  | File name | --output cube2n | Yes |
| --sheets  | List of sheets in generated file | --sheets dataset1 dataset2 | Yes |
| --linearextension  | Generate additional columns with linear dependencies | --l true | No |
| --quadraticextension  | Generate additional columns with quadratic dependencies | --q false | No |
| --seed  | Seed for MersenneTwister | --seed 123 | No |
Table: Common parameters for all benchamarks
<br />
<br />
| Paramater | Description | Sample used | Required |
|:---------:|:-----------:|:-----------:|:--------:|
|--constant|Parameter used to bound variables (d in formulas)|--constant 5| Yes |
|--dimensions|Number of dimensions|--diemnsions 2|Yes|
Table: Parameters only for Cube and Simplex
<br />
<br />
| Paramater | Description | Sample used | Required |
|:---------:|:-----------:|:-----------:|:--------:|
|--radius|Radius of ball|--radius 5| Yes |
|--center|Center of ball (affects the number of dimensions -> X1, X2, X3 etc) |--center 1 2 3 |Yes|
Table: Parameters only for Ball
<br />
<br />

## How to use
Compile and run *dotnet Sparatus.dll*.

### Sample
Invoke Spartacus to generate ball 2d (circle) datasets, output file. 

`dotnet Spartacus.dll ball --center 1 2 --radius 5 -p 100000 --output "FILE_NAME" --outputPath "PATH_TO_SAVE"`

![Visualization](/docs/images/sample_visualization.JPG)
Image: Visualization created dataset

## Contribution
Feel free to make pull request and add something or just create issue with question / suggestion for improvement / report bug.