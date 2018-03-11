﻿// dnlib: See LICENSE.txt for more info

using System;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb.Symbols;
using dnlib.IO;

namespace dnlib.DotNet.Pdb {
	/// <summary>
	/// Creates a <see cref="SymbolReader"/> instance
	/// </summary>
	public static class SymbolReaderCreator {
		/// <summary>
		/// Creates a new <see cref="SymbolReader"/> instance
		/// </summary>
		/// <param name="pdbImpl">PDB implementation to use</param>
		/// <param name="metadata">.NET metadata</param>
		/// <param name="assemblyFileName">Path to assembly</param>
		/// <returns>A new <see cref="SymbolReader"/> instance or <c>null</c> if there's no PDB
		/// file on disk or if it's not possible to create a <see cref="SymbolReader"/>.</returns>
		public static SymbolReader CreateFromAssemblyFile(PdbImplType pdbImpl, Metadata metadata, string assemblyFileName) {
			switch (pdbImpl) {
			case PdbImplType.MicrosoftCOM:
				return Dss.SymbolReaderCreator.CreateFromAssemblyFile(assemblyFileName);

			case PdbImplType.Managed:
				return ManagedSymbolReaderCreator.CreateFromAssemblyFile(metadata, assemblyFileName);

			default: throw new InvalidOperationException();
			}
		}

		/// <summary>
		/// Creates a new <see cref="SymbolReader"/> instance
		/// </summary>
		/// <param name="pdbImpl">PDB implementation to use</param>
		/// <param name="metadata">.NET metadata</param>
		/// <param name="pdbFileName">Path to PDB file</param>
		/// <returns>A new <see cref="SymbolReader"/> instance or <c>null</c> if there's no PDB
		/// file on disk or if it's not possible to create a <see cref="SymbolReader"/>.</returns>
		public static SymbolReader Create(PdbImplType pdbImpl, Metadata metadata, string pdbFileName) {
			switch (pdbImpl) {
			case PdbImplType.MicrosoftCOM:
				return Dss.SymbolReaderCreator.Create(metadata, pdbFileName);

			case PdbImplType.Managed:
				return ManagedSymbolReaderCreator.Create(metadata, pdbFileName);

			default: throw new InvalidOperationException();
			}
		}

		/// <summary>
		/// Creates a new <see cref="SymbolReader"/> instance
		/// </summary>
		/// <param name="pdbImpl">PDB implementation to use</param>
		/// <param name="metadata">.NET metadata</param>
		/// <param name="pdbData">PDB file data</param>
		/// <returns>A new <see cref="SymbolReader"/> instance or <c>null</c> if it's not possible
		/// to create a <see cref="SymbolReader"/>.</returns>
		public static SymbolReader Create(PdbImplType pdbImpl, Metadata metadata, byte[] pdbData) {
			switch (pdbImpl) {
			case PdbImplType.MicrosoftCOM:
				return Dss.SymbolReaderCreator.Create(metadata, pdbData);

			case PdbImplType.Managed:
				return ManagedSymbolReaderCreator.Create(metadata, pdbData);

			default: throw new InvalidOperationException();
			}
		}

		/// <summary>
		/// Creates a new <see cref="SymbolReader"/> instance
		/// </summary>
		/// <param name="pdbImpl">PDB implementation to use</param>
		/// <param name="metadata">.NET metadata</param>
		/// <param name="pdbStream">PDB file stream which is now owned by us</param>
		/// <returns>A new <see cref="SymbolReader"/> instance or <c>null</c> if it's not possible
		/// to create a <see cref="SymbolReader"/>.</returns>
		public static SymbolReader Create(PdbImplType pdbImpl, Metadata metadata, IImageStream pdbStream) {
			switch (pdbImpl) {
			case PdbImplType.MicrosoftCOM:
				return Dss.SymbolReaderCreator.Create(metadata, pdbStream);

			case PdbImplType.Managed:
				return ManagedSymbolReaderCreator.Create(metadata, pdbStream);

			default:
				if (pdbStream != null)
					pdbStream.Dispose();
				throw new InvalidOperationException();
			}
		}

		internal static SymbolReader Create(PdbImplType pdbImpl, Metadata metadata) {
			switch (pdbImpl) {
			case PdbImplType.MicrosoftCOM:
				return null;

			case PdbImplType.Managed:
				return ManagedSymbolReaderCreator.Create(metadata);

			default:
				throw new InvalidOperationException();
			}
		}
	}
}
