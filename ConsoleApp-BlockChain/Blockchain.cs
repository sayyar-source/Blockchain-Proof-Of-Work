using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_BlockChain
{
   public class Blockchain
    {
        public IList<Block> chain { get; set; }
        public int Difficulty { set; get; } = 1;
        public Blockchain()
        {
            InitializeChain();
            AddGenesisBlock();
        }
        //Initialize
        private void InitializeChain()
        {
            chain = new List<Block>();
        }
        private void AddGenesisBlock()
        {
            chain.Add(CreateGenesisBlock());
        }
        public Block CreateGenesisBlock()
        {
            return new Block(DateTime.Now, null, "{}");
        }
        //end Initialize

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Mine(this.Difficulty);
            chain.Add(block);
        }
        public Block GetLatestBlock()
        {
            return chain[chain.Count - 1];
        }
     
     
        public bool IsValid()
        {
            for (int i = 1; i < chain.Count; i++)
            {
                Block currentBlock = chain[i];
                Block previousBlock = chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
