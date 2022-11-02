namespace DataAccess
{
	public class GenericRepository<TEntity> where TEntity : class
	{
		internal EcpContext context;
		internal DbSet<TEntity> dbSet;

		public GenericRepository(EcpContext context)
		{
			this.context = context;
			dbSet = context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return dbSet.ToList();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public async Task InsertAsync(TEntity entity)
		{
			await dbSet.AddAsync(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public async Task DeleteAsync(object id)
		{
			TEntity entityToDelete = await dbSet.FindAsync(id);
			await DeleteAsync(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}

		public async Task DeleteAsync(TEntity entityToDelete)
		{
			await Task.Run(() =>
			{
				if (context.Entry(entityToDelete).State == EntityState.Detached)
				{
					dbSet.Attach(entityToDelete);
				}
				dbSet.Remove(entityToDelete);
			});
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		public async Task UpdateAsync(TEntity entityToUpdate)
		{
			await Task.Run(() =>
			{
				dbSet.Attach(entityToUpdate);
				context.Entry(entityToUpdate).State = EntityState.Modified;
			});
		}

		public async Task SaveAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}
