using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

Enum.GetValues(typeof(TaskInterval));
Enum.GetValues(typeof(TaskStatus));

Console.WriteLine("【EFCore AOT】开始测试...");

var sw = new Stopwatch();

using (var ctx = new TaskInfoDbContext())
{
	var data = GetRandData(1);
	sw.Reset();
	sw.Start();
	ctx.Add(data);
	sw.Stop();
	Console.WriteLine($"Insert 1条 {sw.ElapsedMilliseconds}ms");

	sw.Reset();
	sw.Start();
	var find = ctx.Set<TaskInfo>().Where(a => a.Id == data[0].Id).First();
	sw.Stop();
	Console.WriteLine($"Select 1条 {sw.ElapsedMilliseconds}ms{(find.ToString() == data[0].ToString() ? "" : $"，错误：查询内容与插入的内容不相同！！！\r\n插入: {data[0]}\r\n查询: {find}")}");

	sw.Reset();
	sw.Start();
	find.Topic = Guid.NewGuid().ToString();
	ctx.Update(find);
	sw.Stop();
	Console.WriteLine($"Update 1条 {sw.ElapsedMilliseconds}ms");

	sw.Reset();
	sw.Start();
	var find2 = ctx.Set<TaskInfo>().Where(a => a.Id == find.Id).First();
	sw.Stop();
	Console.WriteLine($"Select 1条 {sw.ElapsedMilliseconds}ms{(find2.ToString() == find.ToString() ? "" : "，错误：查询内容与更新的内容不相同！！！")}");

	sw.Reset();
	sw.Start();
	ctx.Remove(find);
	sw.Stop();
	Console.WriteLine($"Delete 1条 {sw.ElapsedMilliseconds}ms{(ctx.Set<TaskInfo>().Where(a => a.Id == find.Id).Any() == false ? "" : "，错误：删除操作后，内容依然存在！！！")}");
}

Console.WriteLine("【EFCore AOT】测试结束.");

List<TaskInfo> GetRandData(int size)
{
	return Enumerable.Range(0, size).Select(a => new TaskInfo
	{
		Id = Guid.NewGuid().ToString(),
		Topic = Guid.NewGuid().ToString(),
		Body = Guid.NewGuid().ToString(),
		Round = a,
		Interval = TaskInterval.RunOnMonth,
		IntervalArgument = Guid.NewGuid().ToString(),
		CreateTime = DateTime.Now,
		LastRunTime = DateTime.Now,
		CurrentRound = a,
		ErrorTimes = a,
		Status = TaskStatus.Completed
	}).ToList();
}

class TaskInfoDbContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite($"Data Source={AppContext.BaseDirectory}/test1.db");
	}
}
public class TaskInfo
{
	public string Id { get; set; }
	public string Topic { get; set; }
	public string Body { get; set; }
	public int Round { get; set; }
	public TaskInterval Interval { get; set; }
	public string IntervalArgument { get; set; }
	public DateTime CreateTime { get; set; }
	public DateTime LastRunTime { get; set; }

	public int CurrentRound { get; set; }
	public int ErrorTimes { get; set; }
	public TaskStatus Status { get; set; }

	public override string ToString() =>
		$"{Id},{Topic},{Body},{Round},{Interval},{IntervalArgument},{CreateTime.ToString("yyyy-MM-dd HH:mm:ss")},{LastRunTime.ToString("yyyy-MM-dd HH:mm:ss")}" +
		$",{CurrentRound},{ErrorTimes},{Status}";
}
public enum TaskStatus { Running, Paused, Completed }
public enum TaskInterval { SEC = 1, RunOnDay = 11, RunOnWeek = 12, RunOnMonth = 13, Custom = 21 }