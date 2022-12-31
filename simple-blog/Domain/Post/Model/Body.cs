using System;
namespace simple_blog.Domain.Post.Model
{
	public class Body
	{
		private static readonly int MIN_CHARS = 10;

        public string aBody { get; set; }

        public Body(string body)
		{
			if (body.Length < MIN_CHARS)
			{
				throw new Exception($"The min length for Body is {MIN_CHARS} chars");
			}

			aBody = body;
		}
	}
}

