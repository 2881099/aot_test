aot_test ���ڲ��� AOT �����Ľ�� [2023-11-19]

## FreeSql v3.2.805 + Sqlite

```shell
������ʱ 31.882 ��

orm_freesql.exe    ( 16,927KB)
orm_freesql.pdb    (123,812KB)
SQLite.Interop.dll (  1,723KB)

E:\github\aot_test\orm_freesql\bin\Release\net8.0\publish\win-x64>orm_freesql.exe
��FreeSql AOT����ʼ����...
Insert 1�� 80ms
Select 1�� 5ms
Update 1�� 86ms
Select 1�� 0ms
Delete 1�� 74ms
��FreeSql AOT�����Խ���.
```

PS��û�ж� AOT ��֧����ר�ŸĽ��������ϴ��롣

## SqlSugar v5.1.4.117 + Sqlite

```shell
������ʱ 01:22.813 ����

orm_sqlsugar.exe                   ( 39,875KB)
orm_sqlsugar.pdb                   (266,084KB)
e_sqlite3                        (  1,597KB)
Microsoft.Data.SqlClient.SNI.dll (    499KB)

E:\github\aot_test\orm_sqlsugar\bin\Release\net8.0\publish\win-x64>orm_sqlsugar.exe
��SqlSugar AOT����ʼ����...
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

������ .CodeFirst.InitTables\<TaskInfo\>() ����ȥ���ô����ֹ�������֮���ٴη������У�

```shell
������ʱ 59.911 ��

E:\github\aot_test\orm_sqlsugar\bin\Release\net8.0\publish\win-x64>orm_sqlsugar.exe
��SqlSugar AOT����ʼ����...
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

����� .Insertable �����޽⣿���滹�Ǹ��¡���ѯ����ûִ��~~

https://www.cnblogs.com/sunkaixuan/p/17839825.html
��NET8 ORM ʹ��AOT SqlSugar posted�� @ 2023-11-17 22:31 ���Ǵ����ݿƼ�

��ƪ����������� FreeSql 2023-11-16 ���� AOT ���·���ô��

https://www.cnblogs.com/FreeSql/p/17836000.html
��.NET8.0 AOT ������� FreeSql/FreeRedis/FreeScheduler ����ͨ�����ԡ� posted @ 2023-11-16 14:18  FreeSql

FreeSql һ��û�������ˣ���һ�ξͱ���� seo �ؼ��֣��ô��Ȳ������ٷ����°���~~

## EFCore v8.0 + Sqlite

```shell
������ʱ 01:22.813 ����

orm_efcore.exe     ( 17,410KB)
orm_efcore.pdb     (168,788KB)
e_sqlite3          (  1,652KB)

E:\github\aot_test\orm_efcore\bin\Release\net8.0\publish\win-x64>orm_efcore.exe
��EFCore AOT����ʼ����...
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

Dapper �Ѿ������µ� DapperAOT �汾���Ͳ������ˣ�100%֧�� AOT��