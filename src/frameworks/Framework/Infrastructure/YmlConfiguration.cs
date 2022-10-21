namespace Microsoft.Extensions.Configuration;

public static class YamlConfigurationExtensions : object
{
	static YamlConfigurationExtensions()
	{
	}

	public static IConfigurationBuilder
		AddYmlFile(this IConfigurationBuilder builder, string path)
	{
		return AddYmlFile
			(builder, provider: null, path: path,
			optional: false, reloadOnChange: false);
	}

	public static IConfigurationBuilder
		AddYmlFile(this IConfigurationBuilder builder, string path, bool optional)
	{
		return AddYmlFile
			(builder, provider: null, path: path,
			optional: optional, reloadOnChange: false);
	}

	public static IConfigurationBuilder
		AddYmlFile(this IConfigurationBuilder builder,
		string path, bool optional, bool reloadOnChange)
	{
		return AddYmlFile
			(builder, provider: null, path: path,
			optional: optional, reloadOnChange: reloadOnChange);
	}

	public static IConfigurationBuilder
		AddYmlFile(this IConfigurationBuilder builder,
		FileProviders.IFileProvider provider, string path, bool optional, bool reloadOnChange)
	{
		if (provider == null && System.IO.Path.IsPathRooted(path))
		{
			provider =
				new
				FileProviders.PhysicalFileProvider
				(System.IO.Path.GetDirectoryName(path));

			path = System.IO.Path.GetFileName(path);
		}

		var source =
			new
			NetEscapades.Configuration.Yaml.YamlConfigurationSource
			{
				Path = path,
				Optional = optional,
				FileProvider = provider,
				ReloadOnChange = reloadOnChange,
			};

		builder.Add(source);

		return builder;
	}
}
