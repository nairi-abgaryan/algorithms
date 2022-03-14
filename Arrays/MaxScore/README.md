**2155. All Divisions With the Highest Score of a Binary Array**

<div><p>You are given a <strong>0-indexed</strong> binary array <code>nums</code> of length <code>n</code>. <code>nums</code> can be divided at index <code>i</code> (where <code>0 &lt;= i &lt;= n)</code> into two arrays (possibly empty) <code>nums<sub>left</sub></code> and <code>nums<sub>right</sub></code>:</p>

<ul>
	<li><code>nums<sub>left</sub></code> has all the elements of <code>nums</code> between index <code>0</code> and <code>i - 1</code> <strong>(inclusive)</strong>, while <code>nums<sub>right</sub></code> has all the elements of nums between index <code>i</code> and <code>n - 1</code> <strong>(inclusive)</strong>.</li>
	<li>If <code>i == 0</code>, <code>nums<sub>left</sub></code> is <strong>empty</strong>, while <code>nums<sub>right</sub></code> has all the elements of <code>nums</code>.</li>
	<li>If <code>i == n</code>, <code>nums<sub>left</sub></code> has all the elements of nums, while <code>nums<sub>right</sub></code> is <strong>empty</strong>.</li>
</ul>

<p>The <strong>division score</strong> of an index <code>i</code> is the <strong>sum</strong> of the number of <code>0</code>'s in <code>nums<sub>left</sub></code> and the number of <code>1</code>'s in <code>nums<sub>right</sub></code>.</p>

<p>Return <em><strong>all distinct indices</strong> that have the <strong>highest</strong> possible <strong>division score</strong></em>. You may return the answer in <strong>any order</strong>.</p>

<p><strong>Example 1:</strong></p>

<pre><strong>Input:</strong> nums = [0,0,1,0]
<strong>Output:</strong> [2,4]
<strong>Explanation:</strong> Division at index
- 0: nums<sub>left</sub> is []. nums<sub>right</sub> is [0,0,<u><strong>1</strong></u>,0]. The score is 0 + 1 = 1.
- 1: nums<sub>left</sub> is [<u><strong>0</strong></u>]. nums<sub>right</sub> is [0,<u><strong>1</strong></u>,0]. The score is 1 + 1 = 2.
- 2: nums<sub>left</sub> is [<u><strong>0</strong></u>,<u><strong>0</strong></u>]. nums<sub>right</sub> is [<u><strong>1</strong></u>,0]. The score is 2 + 1 = 3.
- 3: nums<sub>left</sub> is [<u><strong>0</strong></u>,<u><strong>0</strong></u>,1]. nums<sub>right</sub> is [0]. The score is 2 + 0 = 2.
- 4: nums<sub>left</sub> is [<u><strong>0</strong></u>,<u><strong>0</strong></u>,1,<u><strong>0</strong></u>]. nums<sub>right</sub> is []. The score is 3 + 0 = 3.
Indices 2 and 4 both have the highest possible division score 3.
Note the answer [4,2] would also be accepted.</pre>
</div>
2155. <a href = 'https://leetcode.com/problems/all-divisions-with-the-highest-score-of-a-binary-array/'>All Divisions With the Highest Score of a Binary Array</a>
