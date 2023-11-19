aot_test 用于测试 AOT 发布的结果 [2023-11-19]

## FreeSql v3.2.805 + Sqlite

```shell
发布耗时 31.882 秒

orm_freesql.exe    ( 16,927KB)
orm_freesql.pdb    (123,812KB)
SQLite.Interop.dll (  1,723KB)

E:\github\aot_test\orm_freesql\bin\Release\net8.0\publish\win-x64>orm_freesql.exe
【FreeSql AOT】开始测试...
Insert 1条 80ms
Select 1条 5ms
Update 1条 86ms
Select 1条 0ms
Delete 1条 74ms
【FreeSql AOT】测试结束.
```

PS：没有对 AOT 的支持做专门改进，都是老代码。

## SqlSugar v5.1.4.117 + Sqlite

```shell
发布耗时 01:22.813 分钟

orm_sqlsugar.exe                   ( 39,875KB)
orm_sqlsugar.pdb                   (266,084KB)
e_sqlite3                        (  1,597KB)
Microsoft.Data.SqlClient.SNI.dll (    499KB)

E:\github\aot_test\orm_sqlsugar\bin\Release\net8.0\publish\win-x64>orm_sqlsugar.exe
【SqlSugar AOT】开始测试...
Unhandled Exception: System.ArgumentNullException: Value cannot be null. (Parameter 'type')
   at System.ArgumentNullException.Throw(String) + 0x2b
   at System.ActivatorImplementation.CreateInstance(Type, Boolean) + 0xe7
   at SqlSugar.InstanceFactory.NoCacheGetCacheInstance[T](String) + 0x84
   at SqlSugar.InstanceFactory.CreateInstance[T](String) + 0x82
   at SqlSugar.InstanceFactory.GetCodeFirst(ConnectionConfig) + 0x3e
   at SqlSugar.SqlSugarProvider.get_CodeFirst() + 0x1a
   at Program.<Main>$(String[] args) + 0x138
   at orm_sqlsugar!<BaseAddress>+0x11f25d3
```

上述由 .CodeFirst.InitTables\<TaskInfo\>() 报错，去掉该代码手工创建表之后，再次发布运行：

```shell
发布耗时 59.911 秒

E:\github\aot_test\orm_sqlsugar\bin\Release\net8.0\publish\win-x64>orm_sqlsugar.exe
【SqlSugar AOT】开始测试...
Unhandled Exception: System.ArgumentNullException: Value cannot be null. (Parameter 'type')
   at System.ArgumentNullException.Throw(String) + 0x2b
   at System.ActivatorImplementation.CreateInstance(Type, Boolean) + 0xe7
   at SqlSugar.InstanceFactory.NoCacheGetCacheInstance[T](String) + 0x84
   at SqlSugar.InstanceFactory.CreateInstance[T](String) + 0x82
   at SqlSugar.InstanceFactory.GetSqlbuilder(ConnectionConfig) + 0x7a
   at SqlSugar.SqlSugarProvider.CreateInsertable[T](T[]) + 0x39
   at SqlSugar.SqlSugarProvider.Insertable[T](T[] insertObjs) + 0x3b
   at SqlSugar.SqlSugarProvider.Insertable[T](List`1 insertObjs) + 0xb5
   at SqlSugar.SqlSugarClient.Insertable[T](List`1) + 0x44
   at Program.<Main>$(String[] args) + 0x1af
   at orm_sqlsugar!<BaseAddress>+0x11f24f3
```

这次由 .Insertable 报错，无解？后面还是更新、查询操作没执行~~

https://www.cnblogs.com/sunkaixuan/p/17839825.html
《NET8 ORM 使用AOT SqlSugar posted》 @ 2023-11-17 22:31 果糖大数据科技

这篇文章是是针对 FreeSql 2023-11-16 发的 AOT 文章发的么？

https://www.cnblogs.com/FreeSql/p/17836000.html
《.NET8.0 AOT 经验分享 FreeSql/FreeRedis/FreeScheduler 均已通过测试》 posted @ 2023-11-16 14:18  FreeSql

FreeSql 一年没发文章了，发一次就被针对 seo 关键字，好歹先测试下再发文章啊！~~

## EFCore v8.0 + Sqlite

```shell
发布耗时 01:22.813 分钟

orm_efcore.exe     ( 17,410KB)
orm_efcore.pdb     (168,788KB)
e_sqlite3          (  1,652KB)

E:\github\aot_test\orm_efcore\bin\Release\net8.0\publish\win-x64>orm_efcore.exe
【EFCore AOT】开始测试...
Unhandled Exception: System.InvalidOperationException: Model building is not supported when publishing with NativeAOT. Use a compiled model.
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.CreateModel(Boolean) + 0x148
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.get_Model() + 0x1c
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite, ServiceProviderEngineScope) + 0x3d
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(ServiceIdentifier, ServiceProviderEngineScope) + 0xa3
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type) + 0x42
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider, Type) + 0x50
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider) + 0x29
   at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies() + 0x32
   at Microsoft.EntityFrameworkCore.DbContext.get_ContextServices() + 0x14f
   at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies() + 0x22
   at Microsoft.EntityFrameworkCore.DbContext.EntryWithoutDetectChanges[TEntity](TEntity entity) + 0x18
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState) + 0x1d
   at Program.<Main>$(String[] args) + 0x1da
   at orm_efcore!<BaseAddress>+0x7c2ab0
```

## Dapper

Dapper 已经出了新的 DapperAOT 版本，就不测试了，100%支持 AOT。