namespace LeetCode.Problems._210_CourseScheduleII;

/**
* https://leetcode.com/problems/course-schedule-ii/
*/
public class Solution  
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        // aggregate preReqs by the dependent course
        var coursePrereqs = new List<int>?[numCourses];
        foreach (var prereq in prerequisites)
        {
            var dependant = prereq[0];
            var dependency = prereq[1];

            var dependencies = coursePrereqs[dependant] ?? [];
            dependencies.Add(dependency);
            coursePrereqs[dependant] = dependencies;
        }

        
        // complete each course by recursively completing any prereqs first
        var completed = new bool[numCourses];
        var result = new List<int>(numCourses);
        for (int course = 0; course < numCourses; course++)
        {
            try
            {
                CompleteCourse(course, coursePrereqs, completed, result, []);
            }
            catch (CircularDependencyException exception)
            {
                return []; // no valid paths
            }
        }

        return result.ToArray();
    }

    private void CompleteCourse(int course, List<int>?[] coursePrereqs, bool[] completed, List<int> result, List<int> dependants)
    {
        if (completed[course])
        {
            return;
        }

        foreach (var prereq in coursePrereqs[course] ?? [])
        {
            if (dependants.Contains(prereq))
            {
                throw new CircularDependencyException();
            }

            List<int> prereqDependants =
            [
                ..dependants,
                course
            ];
            CompleteCourse(prereq, coursePrereqs, completed, result, prereqDependants);
        }
        
        result.Add(course);
        completed[course] = true;
    }
}

internal class CircularDependencyException: Exception {}

